using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KrakJam2022.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] protected InputActionReference movementAction;
        [SerializeField] protected float movementSpeed = 10f;
        [SerializeField] protected float rotationSpeed = 5f;
        [SerializeField] protected Animator animator;
        [SerializeField] protected AnimatorOverrideController walkAnimation;
        [SerializeField] protected AnimatorOverrideController idleAnimation;
        [SerializeField] protected PlayerDisabler disabler;

        private void Awake()
        {
            GameManager.Instance.OnChangeMoveStatus += disabler.SetActivity;
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnChangeMoveStatus -= disabler.SetActivity;
        }

        private void FixedUpdate()
        {
            Vector3 movementVector = Move();
            Rotate(movementVector);
        }

        private Vector3 Move()
        {
            Vector2 moveInput = this.movementAction.action.ReadValue<Vector2>();
            Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);

            this.transform.Translate(moveDirection * Time.deltaTime * this.movementSpeed, Space.World);
            if(moveInput == Vector2.zero) this.SetAnimation(false);
            else this.SetAnimation(true);
            return moveDirection;
        }

        private void SetAnimation(bool isWalking)
        {
            if(isWalking && this.animator.runtimeAnimatorController != this.walkAnimation)
                this.animator.runtimeAnimatorController = this.walkAnimation;
            else if (!isWalking && this.animator.runtimeAnimatorController != this.idleAnimation)
                this.animator.runtimeAnimatorController = this.idleAnimation;
        }

        private void Rotate(Vector3 movementVector)
        {
            if (movementVector.magnitude == 0)
                return;

            Quaternion newRotation = Quaternion.LookRotation(movementVector, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
