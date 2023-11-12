using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GDC.Core;

namespace GDC.Interaction
{
    /// <summary>
    /// 
    /// </summary>
    public class BentoInteraction : MonoBehaviour, IInteractable
    {
        public string InteractableName { get; set; }

        #region Public method
        public void Interact()
        {
            GameManager.DialogueRunner.StartDialogue("Bento");
        }
        #endregion
    }
}