using System.Collections;
using System.Collections.Generic;
using GDC.Core;
using UnityEngine;

namespace GDC.Interaction
{
    /// <summary>
    /// 
    /// </summary>
    public class GiftInteraction : MonoBehaviour, IInteractable
    {
        public string InteractableName { get; set; }

        #region Public method
        public void Interact()
        {
            GameManager.DialogueRunner.StartDialogue("Day1Gift");
        }
        #endregion
    }
}
