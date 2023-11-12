using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GDC.Watering
{
    public class Watering : MonoBehaviour
    {
        [SerializeField] private GameObject WateringCan;
        [SerializeField] private Image WateringLayer;
        private Vector2 originalWateringCanPos;
        private Animator Anim;
        [SerializeField] Animator WaterCeret;
        private RectTransform canvasRect;

        #region MonoBehaviour methods
        private void Start()
        {
            Anim = WateringCan.GetComponent<Animator>();
            originalWateringCanPos = WateringCan.transform.position;
            canvasRect = WateringLayer.canvas.GetComponent<RectTransform>();
        }

        private void Update()
        {
            Vector3 mousePos = Input.mousePosition;
            Vector2 localMousePos;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, mousePos, null, out localMousePos);

            localMousePos.x = Mathf.Clamp(localMousePos.x, canvasRect.rect.xMin, canvasRect.rect.xMax);
            localMousePos.y = Mathf.Clamp(localMousePos.y, canvasRect.rect.yMin, canvasRect.rect.yMax);

            Vector3 worldMousePos = WateringLayer.transform.TransformPoint(localMousePos);

            if (IsMouseInWateringLayer(worldMousePos))
            {
                WateringCan.transform.position = worldMousePos;

                if (Input.GetMouseButtonDown(0))
                {
                    Anim.SetTrigger("Watering");
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    Anim.SetTrigger("Reset");
                    WaterCeret.SetTrigger("Stop");
                }
            }
            else
            {
                WateringCan.transform.position = originalWateringCanPos;
            }
        }
        #endregion

        #region Public methods
        public void playAnimWater()
        {
            WaterCeret.SetTrigger("Play");
        }
        #endregion

        #region Private methods
        private bool IsMouseInWateringLayer(Vector3 mousePosition)
        {
            RectTransform wateringLayerRect = WateringLayer.rectTransform;

            Vector2 localMousePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(wateringLayerRect, mousePosition, null, out localMousePos);

            return wateringLayerRect.rect.Contains(localMousePos);
        }

        #endregion
    }
}
