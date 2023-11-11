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
    public class FadeBlackCommandHandler : Singleton<FadeBlackCommandHandler>
    {
        #region Public methods
        [YarnCommand("fade_out")]
        public static void FadeOut(float duration)
        {
            FadeBlack.FadeOut(duration);
        }



        [YarnCommand("fade_in")]
        public static void FadeIn(float duration)
        {
            FadeBlack.FadeIn(duration);
        }



        [YarnCommand("fade_fullblack")]
        public static void FadeFullBlack()
        {
            FadeBlack.FullBlack();
        }



        [YarnCommand("fade_noblack")]
        public static void FadeNoBlack()
        {
            FadeBlack.NoBlack();
        }
        #endregion
    }
}
