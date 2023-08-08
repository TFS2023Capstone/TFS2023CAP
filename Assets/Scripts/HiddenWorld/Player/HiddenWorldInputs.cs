using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HiddenWorld.Player
{
	public class HiddenWorldInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool crouch;
		public bool sprint;
		public bool interact;
		public bool aim;
		public bool spyglass;
		public bool dash;
		public bool journal;
        public bool pause;

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
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

        public void OnOpenJournal(InputValue value)              //here
        {
			JournalInput(value.isPressed);
        }

        public void OnOpenPause(InputValue value)              //here
        {
            PauseInput(value.isPressed);
        }

        public void OnCrouch(InputValue value)
		{
			CrouchInput(value.isPressed);
		}

		public void OnInteract(InputValue value)
		{
			InteractInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnDash(InputValue value)
		{
			DashInput(value.isPressed);
		}

        public void OnAim(InputValue value)
		{
			AimInput(value.isPressed);
		}
		public void OnSpyglass(InputValue value)
		{
			SpyglassInput(value.isPressed);
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

		public void CrouchInput(bool newCrouchState)
		{
			crouch = newCrouchState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

        private void DashInput(bool newDashState)
        {
			dash = newDashState;
        }

        public void InteractInput(bool newInteractState)
		{
			interact = newInteractState;
		}
		public void AimInput(bool newInteractState)
		{
			aim = newInteractState;
		}
		public void SpyglassInput(bool newInteractState)
		{
			spyglass = newInteractState;
		}

        public void JournalInput(bool newJournalState)
        {
            journal = newJournalState;
        }

        public void PauseInput(bool newPauseState)
        {
            pause = newPauseState;
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