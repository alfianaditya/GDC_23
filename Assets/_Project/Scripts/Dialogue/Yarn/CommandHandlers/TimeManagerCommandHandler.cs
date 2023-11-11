using System.Collections;
using System.Collections.Generic;
using GDC.TimeSystem;
using GDC.Utilities;
using UnityEngine;
using Yarn.Unity;

namespace GDC.Dialogue.Yarn
{
    /// <summary>
    /// 
    /// </summary>
    public class TimeManagerCommandHandler : Singleton<TimeManagerCommandHandler>
    {
        

        #region Public methods
        [YarnCommand("advance_day")]
        public static void AdvanceDay(int day)
        {
            TimeManager.AdvanceDay(day);
        }
        #endregion
    }
}
