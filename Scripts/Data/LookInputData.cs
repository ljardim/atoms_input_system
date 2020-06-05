using NaughtyAttributes;
using UnityEngine;

namespace LJardim.InputSystem {
    [CreateAssetMenu(fileName = "LookInputData", menuName = "LJardim/Inputs/LookInputData", order = 0)]
    public class LookInputData : ScriptableObject {
        [SerializeField][ReadOnly]private Vector2 moveVector;
        [SerializeField][ReadOnly]private bool isZooming;

        public Vector2 MoveVector => moveVector;

        public float X {
            set => moveVector.x = value;
        }

        public float Y {
            set => moveVector.y = value;
        }

        public bool IsZooming {
            get => isZooming;
            set => isZooming = value;
        }

        public bool ZoomClicked { get; set; }
        public bool ZoomReleased { get; set; }
        
        public void ResetInput() {
            moveVector = Vector2.zero;
            IsZooming = false;
        }
    }
}