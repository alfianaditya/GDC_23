using System.Collections;
using UnityEngine;
using GDC.Utilities;
using UnityEngine.UI;

namespace GDC.Misc
{
    /// <summary>
    /// Fades the screen to black.
    /// </summary>
    public class FadeBlack : Singleton<FadeBlack>
    {
        [SerializeField] private CanvasGroup canvasGroup;

        #region MonoBehaviour methods
        protected override void Awake()
        {
            base.Awake();
        }
        #endregion



        #region Public methods
        public static void FadeIn(float duration)
        {
            Instance.StartCoroutine(Instance.FadeBlackIn(duration));

            Instance.canvasGroup.interactable = false;
            Instance.canvasGroup.blocksRaycasts = false;
        }



        public static void FadeOut(float duration)
        {
            Instance.canvasGroup.interactable = true;
            Instance.canvasGroup.blocksRaycasts = true;

            Instance.StartCoroutine(Instance.FadeBlackOut(duration));
        }
        #endregion



        #region Private methods
        private IEnumerator FadeBlackIn(float duration)
        {
            float time = 0f;
            while (time < duration)
            {
                time += UnityEngine.Time.deltaTime;
                float alpha = Mathf.Lerp(1f, 0f, time / duration);
                canvasGroup.alpha = alpha;

                yield return null;
            }
        }



        private IEnumerator FadeBlackOut(float duration)
        {
            float time = 0f;
            while (time < duration)
            {
                time += UnityEngine.Time.deltaTime;
                float alpha = Mathf.Lerp(0f, 1f, time / duration);
                canvasGroup.alpha = alpha;

                yield return null;
            }
        }
        #endregion
    }
}
