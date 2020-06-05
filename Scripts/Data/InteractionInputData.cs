using NaughtyAttributes;
using UnityEngine;

namespace LJardim.InputSystem {
    [CreateAssetMenu(fileName = "InteractionInputData", menuName = "LJardim/Inputs/InteractionInputData", order = 0)]
    public class InteractionInputData : ScriptableObject {
        [SerializeField][ReadOnly]private bool interactClicked;
        [SerializeField][ReadOnly]private bool action1Clicked;
        [SerializeField][ReadOnly]private bool cycleToolForwardClicked;
        [SerializeField][ReadOnly]private bool cycleToolBackwardClicked;
        [SerializeField][ReadOnly]private bool toggleInventoryMenuClicked;

        public bool InteractClicked {
            get => interactClicked;
            set => interactClicked = value;
        }

        public bool Action1Clicked {
            get => action1Clicked;
            set => action1Clicked = value;
        }
        
        public bool CycleToolForwardClicked {
            get => cycleToolForwardClicked;
            set => cycleToolForwardClicked = value;
        }

        public bool CycleToolBackwardClicked {
            get => cycleToolBackwardClicked;
            set => cycleToolBackwardClicked = value;
        }
        
        public bool ToggleInventoryMenuClicked {
            get => toggleInventoryMenuClicked;
            set => toggleInventoryMenuClicked = value;
        }

        public void ResetInput() {
            InteractClicked = false;
            Action1Clicked = false;
            cycleToolForwardClicked = false;
            cycleToolBackwardClicked = false;
            toggleInventoryMenuClicked = false;
        }
    }
}