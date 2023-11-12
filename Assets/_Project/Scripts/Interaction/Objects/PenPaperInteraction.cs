using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GDC.Core;
using GDC.TimeSystem;

namespace GDC.Interaction
{
    /// <summary>
    /// 
    /// </summary>
    public class PenPaperInteraction : MonoBehaviour, IInteractable
    {
        public string InteractableName { get; set; }

        #region Public method
        public void Interact()
        {
            bool isInteracted;
            GameManager.VariableStorage.TryGetValue("$penpaper_interacted", out isInteracted);

            if (!isInteracted)
            {
                TimeManager.DecreaseEnergy(20);
                GameManager.DialogueRunner.StartDialogue("PenPaper");
            }

            else
            {
                GameManager.DialogueRunner.StartDialogue("PenPaper");
            }
        }
        #endregion
    }
}