using System.Collections;
using System.Collections.Generic;
using GDC.Utilities;
using UnityEngine;
using Yarn.Unity;

namespace GDC.Dialogue.Yarn
{
    /// <summary>
    /// 
    /// </summary>
    public class PanelUICommandHandler : Singleton<PanelUICommandHandler>
    {
        [SerializeField] private CanvasGroup panel;        

        #region Public methods
        [YarnCommand("fade_in_panel")]
        public static void FadeInPanel(float duration)
        {
            Instance.StartCoroutine(Instance.FadeInPanelAnimation(duration));
        }



        [YarnCommand("fade_out_panel")]
        public static void FadeOutPanelAnimation(float duration)
        {
            Instance.StartCoroutine(Instance.FadeOutPanelAnimationAnimation(duration));
        }
        #endregion
        
        
        
        #region Private methods
        private IEnumerator FadeOutPanelAnimationAnimation(float duration)
        {
            float elapsedTime = 0f;
            panel.alpha = 1f;
            panel.blocksRaycasts = false;
            panel.interactable = false;

            while (elapsedTime < duration)
            {
                panel.alpha = Mathf.Lerp(1, 0, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            panel.alpha = 0f;
        }



        private IEnumerator FadeInPanelAnimation(float duration)
        {
            float elapsedTime = 0f;
            panel.alpha = 0f;
            panel.blocksRaycasts = false;
            panel.interactable = false;

            while (elapsedTime < duration)
            {
                panel.alpha = Mathf.Lerp(0, 1, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            panel.alpha = 1f;
            panel.blocksRaycasts = true;
            panel.interactable = true;
        }
        #endregion
    }
}
