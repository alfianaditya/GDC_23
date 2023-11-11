using System.Collections;
using System.Collections.Generic;
using GDC.Utilities;
using GDC.Misc;
using Yarn.Unity;
using UnityEngine;

namespace GDC.Dialogue.Yarn
{
    /// <summary>
    /// 
    /// </summary>
    public class CameraShakeCommandHandler : Singleton<CameraShakeCommandHandler>
    {
        [SerializeField] private ScreenShake screenShake;

        #region Public methods
        [YarnCommand("screen_shake")]
        public static void Screen(float duration, float magnitude)
        {
            Instance.screenShake.TriggerShake(duration, magnitude);
        }



        [YarnCommand("screen_shake_toggle")]
        public static void ToggleScreenShake(bool isShaking, float magnitude = 0f)
        {
            Instance.screenShake.ToggleSreenShake(isShaking, magnitude);
        }
        #endregion
    }
}
