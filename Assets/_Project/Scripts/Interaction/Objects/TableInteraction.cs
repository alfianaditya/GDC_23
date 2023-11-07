using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDC.Interaction
{
    /// <summary>
    /// 
    /// </summary>
    public class TableInteraction : MonoBehaviour, IInteractable
    {
        [SerializeField] private string objectName;

        #region Public methods
        public void Interact()
        {
            Debug.Log("Interacting with " + objectName);
        } 
        #endregion
    }
}
