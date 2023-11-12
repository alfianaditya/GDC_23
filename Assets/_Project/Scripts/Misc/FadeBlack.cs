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
        private Coroutine fadeCoroutine;

        #region MonoBehaviour methods
        protected override void Awake()
        {
            base.Awake();
        }
        #endregion



        #region Public methods
        /// <summary>
        /// Fades the screen to white (black alpha from 1 to 0).
        /// </summary>
        /// <param name="duration"></param>
        public static void FadeIn(float duration)
        {
            if (Instance.fadeCoroutine != null) Instance.StopCoroutine(Instance.fadeCoroutine);

            Instance.fadeCoroutine = Instance.StartCoroutine(Instance.FadeBlackIn(duration));

            Instance.canvasGroup.interactable = false;
            Instance.canvasGroup.blocksRaycasts = false;
        }



        /// <summary>
        /// Fades the screen to black (black alpha from 0 to 1).
        /// </summary>
        /// <param name="duration"></param>
        public static void FadeOut(float duration)
        {
            if (Instance.fadeCoroutine != null) Instance.StopCoroutine(Instance.fadeCoroutine);

            Instance.canvasGroup.interactable = true;
            Instance.canvasGroup.blocksRaycasts = true;

            Instance.fadeCoroutine = Instance.StartCoroutine(Instance.FadeBlackOut(duration));
        }



        public static void FullBlack()
        {
            Instance.canvasGroup.alpha = 1f;
            Instance.canvasGroup.interactable = true;
            Instance.canvasGroup.blocksRaycasts = true;
        }



        public static void NoBlack()
        {
            Instance.canvasGroup.alpha = 0f;
            Instance.canvasGroup.interactable = false;
            Instance.canvasGroup.blocksRaycasts = false;
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
