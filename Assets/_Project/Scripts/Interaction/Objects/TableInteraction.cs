using System.Collections;
using System.Collections.Generic;
using GDC.Misc;
using GDC.Time;
using UnityEngine;

namespace GDC.Interaction
{
    /// <summary>
    /// 
    /// </summary>
    public class TableInteraction : MonoBehaviour, IInteractable
    {
        private Coroutine coroutine;
        [field:SerializeField] public string InteractableName { get; private set; }

        #region Public methods
        public void Interact()
        {
            if (coroutine != null)
            {
                return;
            }

            coroutine = StartCoroutine(Wait());
        } 
        #endregion



        #region Private methods
        private IEnumerator Wait()
        {
            FadeBlack.FadeOut(1);
            yield return new WaitForSeconds(2);
            TimeManager.AdvanceTime(1);
            FadeBlack.FadeIn(1);
            coroutine = null;
        }
        #endregion
    }
}
