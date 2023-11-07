using System.Collections;
using System.Collections.Generic;
using GDC.Player;
using UnityEngine;

namespace GDC.Interaction
{
    /// <summary>
    /// Handles interaction UI.
    /// </summary>
    public class InteractionUI : MonoBehaviour
    {
        [SerializeField] private Interact interact;
        [SerializeField] private CanvasGroup canvasGroup;

        #region MonoBehaviour methods
        private void Update()
        {
            CheckInteractable();
        }
        #endregion
        
        
        
        #region Private methods
        private void CheckInteractable()
        {
            if (interact.InteractableObject != null)
            {
                canvasGroup.alpha = 1;
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
            }

            else
            {
                canvasGroup.alpha = 0;
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            }
        }
        #endregion
    }
}
