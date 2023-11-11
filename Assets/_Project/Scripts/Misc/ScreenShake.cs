using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GDC.Misc
{
    /// <summary>
    /// Screen shake effect.
    /// </summary>
    public class ScreenShake : MonoBehaviour
    {
        private Vector3 originalPosition;
        private bool isShaking = false;
        private float shakeMagnitude;

        #region MonoBehaviour methods
        private void Start()
        {
            originalPosition = transform.position;
        }



        private void Update()
        {
            if (isShaking)
            {
                Shaking(shakeMagnitude);
            }
        }
        #endregion



        #region Public methods
        public void TriggerShake(float shakeDuration, float shakeMagnitude)
        {
            StartCoroutine(Shake(shakeDuration, shakeMagnitude));
        }



        public void ToggleSreenShake(bool isShaking, float shakeMagnitude)
        {
            if (!isShaking)
            {
                transform.position = originalPosition;
            }

            this.isShaking = isShaking;
            this.shakeMagnitude = shakeMagnitude;
        }
        #endregion
        
        
        
        #region Private methods
        private IEnumerator Shake(float shakeDuration, float shakeMagnitude)
        {
            float elapsed = 0.0f;

            while (elapsed < shakeDuration)
            {
                float x = originalPosition.x + Random.Range(-1f, 1f) * shakeMagnitude;
                float y = originalPosition.y + Random.Range(-1f, 1f) * shakeMagnitude;

                transform.position = new Vector3(x, y, originalPosition.z);

                elapsed += Time.deltaTime;

                yield return null;
            }

            transform.position = originalPosition;
        }



        private void Shaking(float shakeMagnitude)
        {
            float x = originalPosition.x + Random.Range(-1f, 1f) * shakeMagnitude;
            float y = originalPosition.y + Random.Range(-1f, 1f) * shakeMagnitude;

            transform.position = new Vector3(x, y, originalPosition.z);
        }
        #endregion
    }
}
