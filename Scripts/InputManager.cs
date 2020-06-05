using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace LJardim.InputSystem {
    public class InputManager : MonoBehaviour {
        [Space, Header("Inputs - Movement")]
        [SerializeField]private StringReference horizontalInput = new StringReference("Horizontal");
        [SerializeField]private StringReference verticalInput = new StringReference("Vertical");
        [SerializeField]private StringReference jumpInput = new StringReference("Jump");
        [SerializeField]private StringReference runInput = new StringReference("Run");
        [SerializeField]private StringReference crouchInput = new StringReference("Crouch");
        
        [Space, Header("Inputs - Look")]
        [SerializeField]private StringReference mouseXInput = new StringReference("Mouse X");
        [SerializeField]private StringReference mouseYInput = new StringReference("Mouse Y");
        [SerializeField]private StringReference zoomInput = new StringReference("Zoom");
        
        [Space, Header("Inputs - Interact")]
        [SerializeField]private StringReference interactInput = new StringReference("Interact");
        [SerializeField]private StringReference action1Input = new StringReference("Action1");
        [SerializeField]private StringReference cycleToolForwardInput = new StringReference("CycleToolForward");
        [SerializeField]private StringReference cycleToolBackwardInput = new StringReference("CycleToolBackward");
        [SerializeField]private StringReference toggleInventoryInput = new StringReference("ToggleInventory");

        [Header("Outputs")]
        [SerializeField]private MovementInputData movementData;
        [SerializeField]private LookInputData lookInputData;
        [SerializeField]private InteractionInputData interactionInputData;

        private void Start() {
            lookInputData.ResetInput();
            movementData.ResetInput();
            interactionInputData.ResetInput();
        }
        
        private void Update() {
            // Get Movement Inputs
            movementData.Horizontal = Input.GetAxis(horizontalInput.Value);
            movementData.Vertical = Input.GetAxis(verticalInput.Value);
            movementData.Jump = Input.GetButtonDown(jumpInput.Value);
            movementData.IsRunning = Input.GetButton(runInput.Value);
            movementData.CrouchClicked = Input.GetButtonDown(crouchInput.Value);

            // Get Camera Inputs
            lookInputData.X = Input.GetAxis(mouseXInput.Value);
            lookInputData.Y = Input.GetAxis(mouseYInput.Value);
            lookInputData.ZoomClicked = Input.GetButtonDown(zoomInput.Value);
            lookInputData.ZoomReleased = Input.GetButtonUp(zoomInput.Value);
            
            // Get Interaction Inputs
            interactionInputData.InteractClicked = Input.GetButtonDown(interactInput.Value);
            interactionInputData.Action1Clicked = Input.GetButtonDown(action1Input.Value);
            interactionInputData.CycleToolForwardClicked = Input.GetButtonDown(cycleToolForwardInput.Value);
            interactionInputData.CycleToolBackwardClicked = Input.GetButtonDown(cycleToolBackwardInput.Value);
            interactionInputData.ToggleInventoryMenuClicked = Input.GetButtonDown(toggleInventoryInput.Value);
        }
    }
}