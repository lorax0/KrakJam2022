using UnityEngine;
using UnityEngine.InputSystem;

namespace KrakJam2022.Player
{
    public class PlayerRay : MonoBehaviour
    {
        [SerializeField] protected float rayDistance = 2.5f;
        [SerializeField] protected InputActionReference useAction;

        private bool isBusy = false;
        private IInteractable interactableItem;

        private void Update()
        {
            if (!isBusy)
                CastRay();
            else
                InputActionManager.WasPressedButtonThisFrame(this.useAction, ExitObject);
        }

        public void Reset()
        {
            if (interactableItem != null)
                interactableItem.ExitInteraction();
        }

        private Vector3 GetPlayerDirection()
        {
            return transform.TransformDirection(Vector3.forward);
        }

        private void CastRay()
        {
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, GetPlayerDirection(), out hit, this.rayDistance))
            {
                InputActionManager.WasPressedButtonThisFrame(this.useAction, () => UseObject(hit.transform.gameObject));
            }
        }

        private void UseObject(GameObject gameObject)
        {
            interactableItem = gameObject.GetComponent<IInteractable>();
            if (interactableItem == null)
                return;

            isBusy = true;
            interactableItem.EnterInteraction();
        }

        private void ExitObject()
        {
            isBusy = false;
            interactableItem.ExitInteraction();
            interactableItem = null;
        }

        private void OnDrawGizmos()
        {
            Debug.DrawRay(this.transform.position, GetPlayerDirection() * this.rayDistance, Color.green);
        }
    }
}