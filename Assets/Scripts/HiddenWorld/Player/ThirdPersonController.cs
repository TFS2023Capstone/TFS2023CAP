﻿using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
using System.Collections;


/* Note: animations are called via the controller for both the character and capsule using animator null checks
 */

namespace HiddenWorld.Player
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerInput))]
    public class ThirdPersonController : MonoBehaviour
    {
        [Header("Player")]
        [Tooltip("Move speed of the character in m/s")]
        public float moveSpeed = 2.0f;

        [Tooltip("Sprint speed of the character in m/s")]
        public float sprintSpeed = 5.335f;

        [Tooltip("How fast the character turns to face movement direction")]
        [Range(0.0f, 0.3f)]
        public float rotationSmoothTime = 0.12f;

        [Tooltip("Acceleration and deceleration")]
        public float speedChangeRate = 10.0f;

        public AudioClip landingAudioClip;
        public AudioClip[] footstepAudioClips;
        [Range(0, 1)] public float footstepAudioVolume = 0.5f;

        [Space(10)]
        [Tooltip("The height the player can jump")]
        public float jumpHeight = 1.2f;

        [Tooltip("The height of the player when crouching and Standing")]
        public float crouchHeight = 1.0f;
        public float standingHeight = 1.8f;
        public float timeToCrouch = 0.25f;
        public Vector3 crouchCenter = new Vector3(0, 0.52f, 0);
        public Vector3 standingCenter = new Vector3(0, 0.93f, 0);
        public GameObject HeadPosition;

        [Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
        public float gravity = -15.0f;

        [Space(10)]
        [Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
        public float jumpTimeout = 0.50f;

        [Tooltip("Time required to pass before entering the fall state. Useful for walking down stairs")]
        public float fallTimeout = 0.15f;

        [Header("Player Grounded")]
        [Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
        public bool grounded = true;

        [Tooltip("Useful for rough ground")]
        public float groundedOffset = -0.14f;

        [Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
        public float groundedRadius = 0.28f;

        [Tooltip("What layers the character uses as ground")]
        public LayerMask groundLayers;

        [Header("Cinemachine")]
        [Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
        public GameObject cinemachineCameraTarget;

        [FormerlySerializedAs("TopClamp")]
        [Tooltip("How far in degrees can you move the camera up")]
        public float topClamp = 70.0f;

        [FormerlySerializedAs("BottomClamp")]
        [Tooltip("How far in degrees can you move the camera down")]
        public float bottomClamp = -30.0f;

        [FormerlySerializedAs("CameraAngleOverride")]
        [Tooltip("Additional degrees to override the camera. Useful for fine tuning camera position when locked")]
        public float cameraAngleOverride = 0.0f;

        [FormerlySerializedAs("LockCameraPosition")]
        [Tooltip("For locking the camera position on all axis")]
        public bool lockCameraPosition = false;

        [Space(10)]
        [Tooltip("determine if you can double jump")]
        private int _currentJumpAmount = 0;

        [Space(10)]
        [Tooltip("determine if you can double jump")]
        [SerializeField]
        private int _maxJumpAmount = 2;

        // cinemachine
        private float _cinemachineTargetYaw;
        private float _cinemachineTargetPitch;

        // player
        private float _speed;
        private float _animationBlend;
        private float _targetRotation = 0.0f;
        private float _rotationVelocity;
        private float _verticalVelocity;
        private float _terminalVelocity = 53.0f;
        

        // timeout deltatime
        private float _jumpTimeoutDelta;
        private float _fallTimeoutDelta;

        // animation IDs
        private int _animIDSpeed;
        private int _animIDGrounded;
        private int _animIDJump;
        private int _animIDCrouch;
        private int _animIDFreeFall;
        private int _animIDMotionSpeed;

        private PlayerInput _playerInput;
        private Animator _animator;
        private CharacterController _controller;
        private HiddenWorldInputs _input;
        private GameObject _mainCamera;

        private const float Threshold = 0.01f;

        private bool _hasAnimator;

        private bool IsCurrentDeviceMouse => _playerInput.currentControlScheme == "KeyboardMouse";


        private void Awake()
        {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            HeadPosition = GameObject.FindGameObjectWithTag("PlayerHead");
        }

        private void Start()
        {
            _cinemachineTargetYaw = cinemachineCameraTarget.transform.rotation.eulerAngles.y;

            _hasAnimator = TryGetComponent(out _animator);
            _controller = GetComponent<CharacterController>();
            _input = GetComponent<HiddenWorldInputs>();
            _playerInput = GetComponent<PlayerInput>();

            AssignAnimationIDs();

            // reset our timeouts on start
            _jumpTimeoutDelta = jumpTimeout;
            _fallTimeoutDelta = fallTimeout;
        }

        private void Update()
        {
            GroundedCheck();
            Interact();
            Crouch();
            JumpAndGravity();
            Move();
        }

        private void LateUpdate()
        {
            CameraRotation();
        }

        private void AssignAnimationIDs()
        {
            _animIDSpeed = Animator.StringToHash("Speed");
            _animIDGrounded = Animator.StringToHash("Grounded");
            _animIDJump = Animator.StringToHash("Jump");
            _animIDCrouch = Animator.StringToHash("Crouch");
            _animIDFreeFall = Animator.StringToHash("FreeFall");
            _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
        }

        private void GroundedCheck()
        {
            // set sphere position, with offset
            Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundedOffset,
                transform.position.z);
            grounded = Physics.CheckSphere(spherePosition, groundedRadius, groundLayers,
                QueryTriggerInteraction.Ignore);
            if (grounded == true)
            {
                _currentJumpAmount = 0;
            }

            // update animator if using character
            if (_hasAnimator)
            {
                _animator.SetBool(_animIDGrounded, grounded);
            }
        }

        private void CameraRotation()
        {
            // if there is an input and camera position is not fixed
            if (_input.look.sqrMagnitude >= Threshold && !lockCameraPosition)
            {
                //Don't multiply mouse input by Time.deltaTime;
                float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

                _cinemachineTargetYaw += _input.look.x * deltaTimeMultiplier;
                _cinemachineTargetPitch += _input.look.y * deltaTimeMultiplier;
            }

            // clamp our rotations so our values are limited 360 degrees
            _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, bottomClamp, topClamp);

            // Cinemachine will follow this target
            cinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + cameraAngleOverride,
                _cinemachineTargetYaw, 0.0f);
        }

        private float targetSpeed;
        private bool isDashing;

        private IEnumerator Dash(float multiplier, float duration)
        {
            isDashing = true;
            float originalSpeed = targetSpeed;
            targetSpeed *= multiplier;

            yield return new WaitForSeconds(duration);

            targetSpeed = originalSpeed;
            isDashing = false;
            _input.dash = false;
        }

        private void Move()
        {
            targetSpeed = _input.sprint ? sprintSpeed : moveSpeed;

            if (_input.dash && !isDashing)
            {
                StartCoroutine(Dash(150.0f, 0.5f));
            }

            // a simplistic acceleration and deceleration designed to be easy to remove, replace, or iterate upon

            // note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
            // if there is no input, set the target speed to 0
            if (_input.move == Vector2.zero) targetSpeed = 0.0f;

            // a reference to the players current horizontal velocity
            float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

            float speedOffset = 0.1f;
            float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;

            // accelerate or decelerate to target speed
            if (currentHorizontalSpeed < targetSpeed - speedOffset ||
                currentHorizontalSpeed > targetSpeed + speedOffset)
            {
                // creates curved result rather than a linear one giving a more organic speed change
                // note T in Lerp is clamped, so we don't need to clamp our speed
                _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude,
                    Time.deltaTime * speedChangeRate);

                // round speed to 3 decimal places
                // Example .1234 -> 123.4 -> 123.0 -> .123
                _speed = Mathf.Round(_speed * 1000f) / 1000f;
            }
            else
            {
                _speed = targetSpeed;
            }

            _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * speedChangeRate);
            if (_animationBlend < 0.01f) _animationBlend = 0f;

            // normalise input direction
            Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;

            // note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
            // if there is a move input rotate player when the player is moving
            if (_input.move != Vector2.zero)
            {
                _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                                  _mainCamera.transform.eulerAngles.y;
                float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                    rotationSmoothTime);

                // rotate to face input direction relative to camera position
                transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            }


            Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;

            // move the player
            _controller.Move(targetDirection.normalized * (_speed * Time.deltaTime) +
                             new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);

            // update animator if using character
            if (_hasAnimator)
            {
                _animator.SetFloat(_animIDSpeed, _animationBlend);
                _animator.SetFloat(_animIDMotionSpeed, inputMagnitude);
            }
        }                    

        private void JumpAndGravity()
        {
            if (grounded)
            {
                // reset the fall timeout timer
                _fallTimeoutDelta = fallTimeout;

                // update animator if using character
                if (_hasAnimator)
                {
                    _animator.SetBool(_animIDJump, false);
                    _animator.SetBool(_animIDFreeFall, false);
                }

                // stop our velocity dropping infinitely when grounded
                if (_verticalVelocity < 0.0f)
                {
                    _verticalVelocity = -2f;
                }

                // Jump
                if (_input.jump && _jumpTimeoutDelta <= 0.0f)
                {
                    // the square root of H * -2 * G = how much velocity needed to reach desired height
                    _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);

                    _currentJumpAmount++;
                    // update animator if using character
                    if (_hasAnimator)
                    {
                        _animator.SetBool(_animIDJump, true);
                    }
                    // if we are not grounded, do not jump
                    _input.jump = false;
                }

                // jump timeout
                if (_jumpTimeoutDelta >= 0.0f)
                {
                    _jumpTimeoutDelta -= Time.deltaTime;
                }
            }
            else
            {
                //extra Jump
                if (_currentJumpAmount < _maxJumpAmount)
                {
                    if (_input.jump && _jumpTimeoutDelta <= 1.0f)
                    {
                        // the square root of H * -2 * G = how much velocity needed to reach desired height
                        _currentJumpAmount++;
                        _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);

                        // update animator if using character
                        if (_hasAnimator)
                        {
                            _animator.SetBool(_animIDJump, true);
                        }
                        // if we are not grounded, do not jump
                        _input.jump = false;
                    }

                }

                // reset the jump timeout timer
                _jumpTimeoutDelta = jumpTimeout;

                // fall timeout
                if (_fallTimeoutDelta >= 0.0f)
                {
                    _fallTimeoutDelta -= Time.deltaTime;
                }
                else
                {
                    // update animator if using character
                    if (_hasAnimator)
                    {
                        _animator.SetBool(_animIDFreeFall, true);
                    }
                }


                // if we are not grounded, do not jump
                _input.jump = false;
            }

            // apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
            if (_verticalVelocity < _terminalVelocity)
            {
                _verticalVelocity += gravity * Time.deltaTime;
            }
        }

        private void Interact()
        {
        }

        private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360f) lfAngle += 360f;
            if (lfAngle > 360f) lfAngle -= 360f;
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }

        private void OnDrawGizmosSelected()
        {
            Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
            Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

            Gizmos.color = grounded ? transparentGreen : transparentRed;

            // when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
            Gizmos.DrawSphere(
                new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z),
                groundedRadius);
        }

        private void OnFootstep(AnimationEvent animationEvent)
        {
            if (animationEvent.animatorClipInfo.weight > 0.5f)
            {
                if (footstepAudioClips.Length > 0)
                {
                    var index = Random.Range(0, footstepAudioClips.Length);
                    AudioSource.PlayClipAtPoint(footstepAudioClips[index], transform.TransformPoint(_controller.center), footstepAudioVolume);
                }
            }
        }

        private void OnLand(AnimationEvent animationEvent)
        {
            if (animationEvent.animatorClipInfo.weight > 0.5f)
            {
                AudioSource.PlayClipAtPoint(landingAudioClip, transform.TransformPoint(_controller.center), footstepAudioVolume);
            }
        }
        private void Crouch()
        {
            float currentHeight = _controller.height;
            Vector3 currentCenter = _controller.center;
            float timeElapsed = 0;

            if (_input.crouch)
            {
                if (_hasAnimator)
                {
                    _animator.SetBool(_animIDCrouch, true);

                    while (timeElapsed < timeToCrouch)
                    {
                        _controller.height = Mathf.Lerp(currentHeight, crouchHeight, timeElapsed/timeToCrouch);
                        _controller.center = Vector3.Lerp(currentCenter, crouchCenter, timeElapsed / timeToCrouch);
                        timeElapsed += Time.deltaTime;
                    }
                }
            }
            else if (!Physics.Raycast(HeadPosition.transform.position, Vector3.up, 0.8f))
            {
                _animator.SetBool(_animIDCrouch, false);

                while (timeElapsed < timeToCrouch)
                {
                    _controller.height = Mathf.Lerp(currentHeight, standingHeight, timeElapsed / timeToCrouch);
                    _controller.center = Vector3.Lerp(currentCenter, standingCenter, timeElapsed / timeToCrouch);
                    timeElapsed += Time.deltaTime;
                }
            }
        }
    }
}