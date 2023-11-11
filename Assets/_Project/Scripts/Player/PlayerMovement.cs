using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GDC.Utilities;

namespace GDC.Player
{
    /// <summary>
    /// Handles player movement.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Animator animator;
        [SerializeField] private float speed = 5f;
        private bool isDisabled;

        #region MonoBehaviour methods
        private void Update()
        {
            if (isDisabled) return;

            GetInput();
        }



        private void OnEnable()
        {
            EventManager.AddListener<OnDialogue>(OnDialogue);
        }
        #endregion
        
        
        
        #region Private methods
        private void GetInput()
        {
            Vector2 direction = Vector2.zero;

            if (Input.GetKey(KeyCode.W))
            {
                direction += Vector2.up;
            }

            if (Input.GetKey(KeyCode.S))
            {
                direction += Vector2.down;
            }

            if (Input.GetKey(KeyCode.A))
            {
                direction += Vector2.left;
            }

            if (Input.GetKey(KeyCode.D))
            {
                direction += Vector2.right;
            }

            Move(direction);
        }



        private void Move(Vector2 direction)
        {
            rb.velocity = direction.normalized * speed;

            AnimateMove(direction);
            FlipSprite(direction);
        }



        private void AnimateMove(Vector2 direction)
        {
            if (animator == null) return;

            bool isMoving = direction != Vector2.zero;
            animator.SetBool("IsMoving", isMoving);
        }



        private void FlipSprite(Vector2 direction)
        {
            if (direction == Vector2.zero) return;

            transform.rotation = Quaternion.Euler(0f, direction.x > 0 ? 0f : 180f, 0f);
        }



        private void OnDialogue(OnDialogue evt)
        {
            if (evt.isOnDialogue)
            {
                rb.velocity = Vector2.zero;
                animator.SetBool("IsMoving", false);
                isDisabled = true;
            }

            else
            {
                isDisabled = false;
            }
        }
        #endregion
    }
}
