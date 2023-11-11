using System.Collections;
using System.Collections.Generic;
using GDC.Interaction;
using GDC.Utilities;
using UnityEngine;

namespace GDC.Interaction
{
    /// <summary>
    /// Activates an object on a specific day.
    /// </summary>
    public class ObjectActivator : MonoBehaviour
    {
        [SerializeField] private GameObject objectToActivate;
        [SerializeField] private List<int> dayAvailable;

        #region MonoBehaviour methods
        protected virtual void OnEnable()
        {
            EventManager.AddListener<OnTimeAdvanced>(OnTimeAdvanced);
        }



        protected virtual void OnDisable()
        {
            EventManager.RemoveListener<OnTimeAdvanced>(OnTimeAdvanced);
        }
        #endregion



        #region Protected methods
        protected virtual void OnTimeAdvanced(OnTimeAdvanced evt)
        {
            if (dayAvailable.Contains(evt.Day))
            {
                objectToActivate.SetActive(true);
            }

            else
            {
                objectToActivate.SetActive(false);
            }
        }
        #endregion
    }
}
