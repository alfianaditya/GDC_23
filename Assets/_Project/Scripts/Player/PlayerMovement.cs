using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDC.Player
{
    /// <summary>
    /// Handles player movement.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;

        #region MonoBehaviour methods
        private void Update()
        {
            GetInput();
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
            rb.velocity = direction.normalized * 5f;
        }
        #endregion
    }
}
