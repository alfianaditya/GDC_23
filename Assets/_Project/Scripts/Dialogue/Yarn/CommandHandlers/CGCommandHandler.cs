using System.Collections;
using System.Collections.Generic;
using GDC.Dialogue.CG;
using GDC.Utilities;
using UnityEngine;
using Yarn.Unity;

namespace GDC.Dialogue.Yarn
{
    /// <summary>
    /// 
    /// </summary>
    public class CGCommandHandler : Singleton<CGCommandHandler>
    {
        [SerializeField] private CGController CGController;

        #region MonoBehaviour methods
        
        #endregion
        
        
        
        #region Public methods
        [YarnCommand("show_cg")]
        public static void ShowCG(string name, float duration = 1f)
        {
            Instance.CGController.ShowCG(name, duration);
        }



        [YarnCommand("show_cg_animation")]
        public static void ShowCGAnimation(string name, float framePerSecond)
        {
            Instance.CGController.ShowCGAnimation(name, framePerSecond);
        }



        [YarnCommand("hide_cg")]
        public static void HideCG(float duration = 1f)
        {
            Instance.CGController.HideCG(duration);
        }
        #endregion
    }
}
