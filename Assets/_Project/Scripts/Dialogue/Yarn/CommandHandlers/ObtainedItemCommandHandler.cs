using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using GDC.Utilities;
using UnityEngine;
using Yarn.Unity;

namespace GDC
{
    /// <summary>
    /// 
    /// </summary>
    public class ObtainedItemCommandHandler : Singleton<ObtainedItemCommandHandler>
    {
        [SerializeField] private Image itemImage;
        [SerializeField] private Image shadow;
        [SerializeField] private float startYPosition = -700;
        [SerializeField] List<ObtainedItem> obtainedItems = new List<ObtainedItem>();
        private Color shadowOriginalColor;
        private Color itemOriginalColor;

        #region MonoBehaviour methods
        protected override void Awake()
        {
            base.Awake();

            shadowOriginalColor = shadow.color;
            itemOriginalColor = itemImage.color;
        }
        #endregion



        #region Public methods
        [YarnCommand("obtain_item_animation")]
        public static void ObtainItemAnimation(string itemName, float duration)
        {
            ObtainedItem obtainedItem = Instance.obtainedItems.Find(item => item.itemName == itemName);
            Instance.itemImage.sprite = obtainedItem.itemSprite;

            Instance.StartCoroutine(Instance.SlideToTop(3f, duration));
        }
        #endregion
        
        
        
        #region Private methods
        private IEnumerator SlideToTop(float speed, float duration)
        {
            StartCoroutine(Appear(shadow, shadowOriginalColor));
            StartCoroutine(Appear(itemImage, itemOriginalColor));

            itemImage.enabled = true;

            Vector3 startPosition = new Vector3 (itemImage.transform.localPosition.x, startYPosition, itemImage.transform.localPosition.z);
            Vector3 endPosition = new Vector3(itemImage.transform.localPosition.x, 0f, itemImage.transform.localPosition.z);

            float time = 0f;
            while (time < 1f)
            {
                time += Time.deltaTime * speed;
                itemImage.transform.localPosition = Vector3.Lerp(startPosition, endPosition, time);
                yield return null;
            }

            StartCoroutine(Disappear(itemImage, duration, itemOriginalColor));
            StartCoroutine(Disappear(shadow, duration, shadowOriginalColor));
        }



        private IEnumerator Appear(Image image, Color targetColor)
        {
            image.enabled = true;

            float time = 0f;
            while (time < 1f)
            {
                time += Time.deltaTime * 2f;
                Color startColor = new Color(targetColor.r, targetColor.g, targetColor.b, 0f);
                image.color = Color.Lerp(startColor, targetColor, time);
                yield return null;
            }
        }



        private IEnumerator Disappear(Image image, float duration, Color targetColor)
        {
            yield return new WaitForSeconds(duration);

            float time = 0f;
            while (time < 1f)
            {
                time += Time.deltaTime * 2f;
                Color clearColor = new Color(targetColor.r, targetColor.g, targetColor.b, 0f);
                image.color = Color.Lerp(targetColor, clearColor, time);
                yield return null;
            }

            image.enabled = false;
        }
        #endregion
    }



    [System.Serializable]
    public class ObtainedItem
    {
        public string itemName;
        public Sprite itemSprite;
    }
}
