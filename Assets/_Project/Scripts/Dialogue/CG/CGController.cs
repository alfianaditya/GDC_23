using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GDC.Dialogue.CG
{
    /// <summary>
    /// 
    /// </summary>
    public class CGController : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private List<CG> cgs = new List<CG>();
        [SerializeField] private List<CGAnimation> cgAnimations = new List<CGAnimation>();

        #region Public methods
        public void ShowCG(string name, float duration = 1f)
        {
            foreach (CG cg in cgs)
            {
                if (cg.name == name)
                {
                    StartCoroutine(FadeInCGAnimation(cg.sprite, duration));
                }
            }
        }



        public void ShowCGAnimation(string name, float framePerSecond)
        {
            foreach (CGAnimation cgAnimation in cgAnimations)
            {
                if (cgAnimation.name == name)
                {
                    StartCoroutine(AnimateCG(cgAnimation.steps, framePerSecond));
                }
            }
        }



        public void HideCG(float duration = 1f)
        {
            StartCoroutine(FadeOutCGAnimation(duration));
        }
        #endregion



        #region Private methods
        private IEnumerator FadeOutCGAnimation(float duration)
        {
            float time = 0f;
            Color color = spriteRenderer.color;

            while (time < duration)
            {
                time += Time.deltaTime;
                color.a = Mathf.Lerp(1f, 0f, time / duration);
                spriteRenderer.color = color;
                yield return null;
            }

            color.a = 0f;
            spriteRenderer.color = color;

            spriteRenderer.enabled = false;
        }



        private IEnumerator FadeInCGAnimation(Sprite sprite, float duration)
        {
            spriteRenderer.enabled = true;
            spriteRenderer.sprite = sprite;

            float time = 0f;
            Color color = spriteRenderer.color;

            while (time < duration)
            {
                time += Time.deltaTime;
                color.a = Mathf.Lerp(0f, 1f, time / duration);
                spriteRenderer.color = color;
                yield return null;
            }

            color.a = 1f;
            spriteRenderer.color = color;
        }



        private IEnumerator AnimateCG(List<Sprite> steps, float framePerSecond)
        {
            spriteRenderer.enabled = true;
            
            Color color = spriteRenderer.color;
            color.a = 1f;
            spriteRenderer.color = color;

            foreach (Sprite step in steps)
            {
                spriteRenderer.sprite = step;
                yield return new WaitForSeconds(1f / framePerSecond);
            }
        }
        #endregion
    }

    

    [System.Serializable]
    public class CG
    {
        public string name;
        public Sprite sprite;
    }

    [System.Serializable]
    public class CGAnimation
    {
        public string name;
        public List<Sprite> steps = new List<Sprite>();
    }
}
