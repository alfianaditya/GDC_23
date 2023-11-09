using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GDC.Interaction;
using GDC.Utilities;

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



        private void OnTriggerExit2D(Collider2D other)
        {
            interactableObject = null;
            OnInteractableExit evt = new OnInteractableExit();
            EventManager.Broadcast(evt);
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
                    OnInteractable evt = new OnInteractable((component as IInteractable).InteractableName);
                    EventManager.Broadcast(evt);
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
