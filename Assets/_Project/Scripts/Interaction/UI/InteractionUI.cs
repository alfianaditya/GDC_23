using System.Collections;
using System.Collections.Generic;
using GDC.Player;
using GDC.Utilities;
using TMPro;
using UnityEngine;

namespace GDC.Interaction
{
    /// <summary>
    /// Handles interaction UI.
    /// </summary>
    public class InteractionUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI objectText;
        [SerializeField] private CanvasGroup canvasGroup;

        #region MonoBehaviour methods
        private void OnEnable()
        {
            EventManager.AddListener<OnInteractable>(OnInteractable);
            EventManager.AddListener<OnInteractableExit>(OnInteractableExit);
        }



        private void OnDisable()
        {
            EventManager.RemoveListener<OnInteractable>(OnInteractable);
            EventManager.RemoveListener<OnInteractableExit>(OnInteractableExit);
        }
        #endregion
        
        
        
        #region Private methods
        private void OnInteractable(OnInteractable evt)
        {
            canvasGroup.alpha = 1;
            objectText.text = evt.InteractableName;
        }



        private void OnInteractableExit(OnInteractableExit evt)
        {
            canvasGroup.alpha = 0;
        }
        #endregion
    }
}
