using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KrakJam2022
{
    public class Player : MonoBehaviour
    {
        [SerializeField] protected InputActionReference movementAction;
        [SerializeField] protected float movementSpeed = 10f;

        private void FixedUpdate()
        {
            Vector2 moveInput = this.movementAction.action.ReadValue<Vector2>();
            Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
            this.transform.Translate(moveDirection * Time.deltaTime * this.movementSpeed);
        }
    }
}