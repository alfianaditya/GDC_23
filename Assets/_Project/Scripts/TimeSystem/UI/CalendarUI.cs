using System.Collections;
using System.Collections.Generic;
using GDC.Utilities;
using TMPro;
using UnityEngine;

namespace GDC.TimeSystem
{
    /// <summary>
    /// Handles the UI behaviour for the calendar.
    /// </summary>
    public class CalendarUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI dayText;

        #region MonoBehaviour methods
        private void OnEnable()
        {
            EventManager.AddListener<OnTimeAdvanced>(OnTimeAdvanced);
        }



        private void OnDisable()
        {
            EventManager.RemoveListener<OnTimeAdvanced>(OnTimeAdvanced);
        }
        #endregion



        #region Private methods
        private void OnTimeAdvanced(OnTimeAdvanced evt)
        {
            dayText.text = evt.Day.ToString();
        }
        #endregion
    }
}
