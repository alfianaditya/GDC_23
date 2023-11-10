using System.Collections;
using System.Collections.Generic;
using GDC.Utilities;
using UnityEngine;

namespace GDC.TimeSystem
{
    /// <summary>
    /// Manager for all time-related events in the game.
    /// </summary>
    public class TimeManager : Singleton<TimeManager>
    {
        private int currentDay;
        public int CurrentDay { get { return currentDay; } }
        private int energy;
        public int Energy { get { return energy; } }
        public const int MAX_ENERGY = 100;

        #region MonoBehaviour methods
        private void Start()
        {
            AdvanceDay(0);
            SetEnergy(MAX_ENERGY);
        }
        #endregion



        #region Public methods
        /// <summary>
        /// Advances the time by the given amount of hours.
        /// </summary>
        /// <param name="hours"></param>
        public static void AdvanceDay(int days = 1)
        {
            Instance.currentDay += days;

            OnTimeAdvanced evt = new OnTimeAdvanced(Instance.currentDay);
            EventManager.Broadcast(evt);
        }



        public static void SetEnergy(int energy)
        {
            Instance.energy = energy;

            OnEnergyChanged evt = new OnEnergyChanged(Instance.energy);
            EventManager.Broadcast(evt);
        }



        public static void DecreaseEnergy(int amount)
        {
            Instance.energy -= amount;

            OnEnergyChanged evt = new OnEnergyChanged(Instance.energy);
            EventManager.Broadcast(evt);
        }
        #endregion
    }
}
