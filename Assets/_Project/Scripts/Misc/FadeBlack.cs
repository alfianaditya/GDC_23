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
        [SerializeField] private Image fadeImage;

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
        }



        public static void FadeOut(float duration)
        {
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
                fadeImage.color = new Color(0f, 0f, 0f, alpha);

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
                fadeImage.color = new Color(0f, 0f, 0f, alpha);

                yield return null;
            }
        }
        #endregion
    }
}
