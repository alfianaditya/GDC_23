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
    public class ConsoleInteraction : MonoBehaviour, IInteractable
    {
        [field:SerializeField] public string InteractableName { get; set; }

        #region Public method
        public void Interact()
        {
            bool isInteracted;
            GameManager.VariableStorage.TryGetValue("$console_interacted", out isInteracted);

            if (!isInteracted)
            {
                TimeManager.DecreaseEnergy(20);
                GameManager.DialogueRunner.StartDialogue("Console");
            }

            else
            {
                GameManager.DialogueRunner.StartDialogue("Console");
            }
        }
        #endregion
    }
}