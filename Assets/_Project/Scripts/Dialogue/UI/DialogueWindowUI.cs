using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using GDC.Core;

namespace GDC.Dialogue
{
    /// <summary>
    /// Dialogue window UI controller.
    /// </summary>
    public class DialogueWindowUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI dialogue;
        private Coroutine currentCoroutine;

        #region MonoBehaviour methods
        
        #endregion
        
        
        
        #region Public methods
        public void OpenWindow()
        {
            gameObject.SetActive(true);
        }




        public void CloseWindow()
        {
            gameObject.SetActive(false);
        }




        public void EraseText()
        {
            dialogue.text = "";
        }
        #endregion
    }
}
