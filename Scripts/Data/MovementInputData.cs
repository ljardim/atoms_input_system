using NaughtyAttributes;
using UnityEngine;

namespace LJardim.InputSystem {
    [CreateAssetMenu(fileName = "MovementInputData", menuName = "LJardim/Inputs/MovementInputData", order = 0)]
    public class MovementInputData : ScriptableObject {
        [SerializeField][ReadOnly]private Vector2 moveVector;
        [SerializeField][ReadOnly]private bool isRunning;
        [SerializeField][ReadOnly]private bool jump;
        [SerializeField][ReadOnly]private bool isCrouching;

        public float Horizontal {
            get => moveVector.x;
            set => moveVector.x = value;
        }

        public float Vertical {
            get => moveVector.y;
            set => moveVector.y = value;
        }

        public float MoveAmount {
            get {
                var moveAmount = Mathf.Clamp01(Mathf.Abs(MoveVector.x) + Mathf.Abs(MoveVector.y));
                moveAmount = IsRunning ? moveAmount * 2 : moveAmount;
                return moveAmount;
            }
        }
        
        public Vector2 MoveVector => moveVector;

        public Vector3 MoveVector3 => new Vector3(Horizontal, 0, Vertical);

        public bool IsMoving => MoveVector != Vector2.zero;

        public bool IsRunning {
            get => isRunning;
            set => isRunning = value;
        }

        public bool Jump {
            get => jump;
            set => jump = value;
        }

        public bool IsCrouching {
            get => isCrouching;
            set => isCrouching = value;
        }

        public bool CrouchClicked { get; set; }
        
        public void ResetInput() {
            moveVector = Vector2.zero;
            IsCrouching = false;
            IsRunning = false;
            Jump = false;
        }
    }
}