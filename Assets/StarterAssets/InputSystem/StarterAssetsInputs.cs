using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool dance1;
		public bool dance2;
		public bool cameraDistanceCloser;
		public bool cameraDistanceFurther;
		public bool slow;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
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

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnDance1(InputValue value)
		{
			Dance1Input(value.isPressed);
		}
        public void OnDance2(InputValue value)
        {
            Dance2Input(value.isPressed);
        }
		public void OnCameraDistanceCloser(InputValue value)
		{
            CameraDistanceCloserInput(value.isPressed);
        }

		public void OnCameraDistanceFurther(InputValue value)
		{
			CameraDistanceFurtherInput(value.isPressed);
		}

		public void OnSlow(InputValue value)
		{
            SlowInput(value.isPressed);
        }	
#endif


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

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void Dance1Input(bool newDance1State)
		{
			dance1 = newDance1State;
		}
        public void Dance2Input(bool newDance2State)
        {
            dance2 = newDance2State;
        }

		public void CameraDistanceCloserInput(bool newCameraDistanceCloserState)
		{
			cameraDistanceCloser = newCameraDistanceCloserState;
		}

		public void CameraDistanceFurtherInput(bool newCameraDistanceFurtherState)
		{
			cameraDistanceFurther = newCameraDistanceFurtherState;
		}
		public void SlowInput(bool newSlowState)
		{
			slow = newSlowState;
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