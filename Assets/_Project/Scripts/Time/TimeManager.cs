using System.Collections;
using System.Collections.Generic;
using GDC.Utilities;
using UnityEngine;

namespace GDC.Time
{
    /// <summary>
    /// Manager for all time-related events in the game.
    /// </summary>
    public class TimeManager : Singleton<TimeManager>
    {
        private int currentDay;
        public int CurrentDay { get { return currentDay; } }
        private int currentHour;
        public int CurrentHour { get { return currentHour; } }
        private int currentMinute;
        public int CurrentMinute { get { return currentMinute; } }

        #region Public methods
        /// <summary>
        /// Advances the time by the given amount of hours.
        /// </summary>
        /// <param name="hours"></param>
        public static void AdvanceTime(int hours, int minutes = 0)
        {
            Instance.currentHour += hours;
            Instance.currentMinute += minutes;

            if (Instance.currentMinute >= 60)
            {
                Instance.currentHour++;
                Instance.currentMinute -= 60;
            }

            if (Instance.currentHour >= 24)
            {
                Instance.currentDay++;
                Instance.currentHour -= 24;
            }

            OnTimeAdvanced evt = new OnTimeAdvanced(Instance.currentDay, Instance.currentHour, Instance.currentMinute);
            EventManager.Broadcast(evt);
        }
        #endregion
    }
}
