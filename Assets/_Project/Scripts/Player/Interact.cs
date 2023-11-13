using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GDC.Interaction;
using GDC.Utilities;
using TMPro;

namespace GDC.Player
{
    /// <summary>
    /// Handles player interaction with objects.
    /// </summary>
    public class Interact : MonoBehaviour
    {
        private Component interactableObject;
        public Component InteractableObject { get { return interactableObject; } }
        private bool isDisabled;
        [SerializeField] private InteractionUI interactionUI;

        #region MonoBehaviour methods
        private void OnTriggerStay2D(Collider2D other)
        {
            CheckInteractable(other.gameObject);
            interactionUI.OnInteractable((interactableObject as IInteractable).InteractableName);
        }



        private void OnTriggerExit2D(Collider2D other)
        {
            interactableObject = null;
            interactionUI.OnInteractableExit("");
        }



        private void Update()
        {
            if (isDisabled) return;

            GetInput();
        }



        private void OnEnable()
        {
            EventManager.AddListener<OnDialogue>(OnDialogue);
        }



        private void OnDisable()
        {
            EventManager.RemoveListener<OnDialogue>(OnDialogue);
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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (interactableObject != null)
                {
                    (interactableObject as IInteractable).Interact();
                }
            }
        }



        private void OnDialogue(OnDialogue evt)
        {
            isDisabled = evt.isOnDialogue;
        }
        #endregion
    }
}
