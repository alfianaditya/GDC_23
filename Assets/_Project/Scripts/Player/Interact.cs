using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GDC.Interaction;

namespace GDC.Player
{
    /// <summary>
    /// Handles player interaction with objects.
    /// </summary>
    public class Interact : MonoBehaviour
    {
        private Component interactableObject;
        public Component InteractableObject { get { return interactableObject; } }

        #region MonoBehaviour methods
        private void OnTriggerEnter2D(Collider2D other)
        {
            CheckInteractable(other.gameObject);
        }



        private void Update()
        {
            GetInput();
        }
        #endregion
        
        
        
        #region Private methods
        private void CheckInteractable(GameObject obj)
        {
            Component[] components = obj.GetComponents<Component>();

            foreach (Component component in components)
            {
                if (component is IInteractable)
                {
                    interactableObject = component;
                }
            }
        }



        private void GetInput()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (interactableObject != null)
                {
                    (interactableObject as IInteractable).Interact();
                }
            }
        }
        #endregion
    }
}
