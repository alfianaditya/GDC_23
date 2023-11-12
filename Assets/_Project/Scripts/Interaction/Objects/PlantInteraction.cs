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
    public class PlantInteraction : MonoBehaviour, IInteractable
    {
        public string InteractableName { get; set; }

        #region Public method
        public void Interact()
        {
            bool isInteracted;
            GameManager.VariableStorage.TryGetValue("$plant_interacted", out isInteracted);

            if (!isInteracted)
            {
                TimeManager.DecreaseEnergy(20);
                GameManager.DialogueRunner.StartDialogue("Plant");
            }

            else
            {
                GameManager.DialogueRunner.StartDialogue("Plant");
            }
        }
        #endregion
    }
}