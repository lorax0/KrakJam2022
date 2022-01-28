using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KrakJam2022
{
    public class PlayerRay : MonoBehaviour
    {
        [SerializeField] protected float rayDistance = 5.0f;
        [SerializeField] protected InputActionReference useAction;

        void Update()
        {
            Vector3 frontDir = this.transform.TransformDirection(Vector3.forward);
            Debug.DrawRay(this.transform.position, frontDir * this.rayDistance, Color.green);
            RaycastHit hit;
            if (Physics.Raycast(this.transform.position, frontDir, out hit, this.rayDistance))
            {
                this.UseObject(hit.transform.gameObject, hit.distance);
                return;
            }
        }

        private void UseObject(GameObject gameObject, float distance)
        {
            var interactableItem = gameObject.GetComponent<IInteractable>();
            if (interactableItem == null)   return;
            
            if (InputActionManager.WasPressedButtonThisFrame(this.useAction))
            {
                interactableItem.Interact();
            }
        }
    }
}
