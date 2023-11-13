using System.Collections;
using System.Collections.Generic;
using GDC.Player;
using GDC.Utilities;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace GDC.Interaction
{
    /// <summary>
    /// Handles interaction UI.
    /// </summary>
    public class InteractionUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI objectText;
        [SerializeField] private GameObject obj;

        #region MonoBehaviour methods
        private void OnEnable()
        {

        }



        private void OnDisable()
        {

        }
        #endregion
        
        
        
        #region Private methods
        public void OnInteractable(string name)
        {
            obj.SetActive(true);
            objectText.text = name;
        }



        public void OnInteractableExit(string name)
        {
            obj.SetActive(false);
            objectText.text = "";
        }
        #endregion
    }
}
