using UnityEngine;
using UnityEngine.Serialization;

namespace HiddenWorld.Player
{
    public class UICanvasControllerInput : MonoBehaviour
    {

        [FormerlySerializedAs("starterAssetsInputs")] [Header("Output")]
        public HiddenWorldInputs hiddenWorldInputs;

        public void VirtualMoveInput(Vector2 virtualMoveDirection)
        {
            hiddenWorldInputs.MoveInput(virtualMoveDirection);
        }

        public void VirtualLookInput(Vector2 virtualLookDirection)
        {
            hiddenWorldInputs.LookInput(virtualLookDirection);
        }

        public void VirtualJumpInput(bool virtualJumpState)
        {
            hiddenWorldInputs.JumpInput(virtualJumpState);
        }

        public void VirtualSprintInput(bool virtualSprintState)
        {
            hiddenWorldInputs.SprintInput(virtualSprintState);
        }

        public void VirtualInteractInput(bool virtualInteractState)
        {
            hiddenWorldInputs.InteractInput(virtualInteractState);
        }
        
    }

}
