using UnityEngine;
using UnityEngine.InputSystem;

namespace HiddenWorld
{
<<<<<<< Updated upstream:Assets/Scripts/HiddenWorld/HiddenWorldInputs.cs
	public class HiddenWorldInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool interact;
=======
    public class HiddenWorldInputs : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;
        public bool interact;
        public bool aim;
        public bool action;
>>>>>>> Stashed changes:Assets/Scripts/HiddenWorld/Player/HiddenWorldInputs.cs

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
            if (cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        }

        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }

<<<<<<< Updated upstream:Assets/Scripts/HiddenWorld/HiddenWorldInputs.cs
		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
=======
        public void OnInteract(InputValue value)
        {
            InteractInput(value.isPressed);
        }
>>>>>>> Stashed changes:Assets/Scripts/HiddenWorld/Player/HiddenWorldInputs.cs

        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }
        public void OnAim(InputValue value)
        {
            AimInput(value.isPressed);
        }
        public void OnAction(InputValue value)
        {
            ActionInput(value.isPressed);
        }

        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

<<<<<<< Updated upstream:Assets/Scripts/HiddenWorld/HiddenWorldInputs.cs
		public void InteractInput(bool newInteractState)
		{
			interact = newInteractState;
		}
=======
        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }
>>>>>>> Stashed changes:Assets/Scripts/HiddenWorld/Player/HiddenWorldInputs.cs

        public void InteractInput(bool newInteractState)
        {
            interact = newInteractState;
        }
        public void AimInput(bool newInteractState)
        {
            aim = newInteractState;
        }
        public void ActionInput(bool newInteractState)
        {
            action = newInteractState;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}