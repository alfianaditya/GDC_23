using System.Collections;
using System.Collections.Generic;
using GDC.Utilities;
using TMPro;
using UnityEngine;

namespace GDC.Time
{
    /// <summary>
    /// Handles the UI behaviour for the clock.
    /// </summary>
    public class ClockUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeText;
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
            timeText.text = evt.Hours.ToString("00") + ":" + evt.Minutes.ToString("00");
            dayText.text = "Day " + evt.Day + 1.ToString();
        }
        #endregion
    }
}
