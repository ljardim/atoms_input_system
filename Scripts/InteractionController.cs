using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace LJardim.InputSystem {
    /*
     * Interaction controller is put on a game object (Usually the player) that can "INTERACT" with something in the scene. This controller does a sphere cast
     * from the mainCamera directly forward and if it hits something that is configured in the interactableLayer, then it will raise a GameObjectEvent with the
     * hit GameObject.
     */
    public class InteractionController : MonoBehaviour {
        [Space, Header("Data")]
        [SerializeField]private InteractionInputData interactionInputData;

        [Space, Header("Ray Settings")]
        [SerializeField]private float rayDistance = 1.5f;
        [SerializeField]private float raySphereRadius = 0.3f;
        [SerializeField]private LayerMask interactableLayer = ~0;

        [Space, Header("Events")]
        [SerializeField]private GameObjectEvent interactedEvent;

        [Space, Header("UI")]
        [SerializeField]private TextMeshProUGUI interactFeedbackText;

        private Camera _camera;

        private void Start() {
            _camera = Camera.main;
        }

        private void Update() {
            var ray = new Ray(_camera.transform.position, _camera.transform.forward);
            var hitSomething = Physics.SphereCast(ray, raySphereRadius, out var hitInfo, rayDistance, interactableLayer);
            if (!hitSomething) {
                interactFeedbackText.text = "";
                interactFeedbackText.enabled = false;
                return;
            }

            interactFeedbackText.text = hitInfo.transform.name;
            interactFeedbackText.enabled = true;

            if (!interactionInputData.InteractClicked) {
                return;
            }

            interactedEvent.Raise(hitInfo.transform.gameObject);
        }
    }
}