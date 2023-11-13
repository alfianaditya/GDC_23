using System.Collections;
using System.Collections.Generic;
using GDC.Core;
using UnityEngine;

namespace GDC.Interaction
{
    /// <summary>
    /// 
    /// </summary>
    public class DoorInteraction : MonoBehaviour, IInteractable
    {
        [field:SerializeField] public string InteractableName { get; set; }

        #region Public method
        public void Interact()
        {
            GameManager.DialogueRunner.StartDialogue("Door");
        }
        #endregion
    }
}
