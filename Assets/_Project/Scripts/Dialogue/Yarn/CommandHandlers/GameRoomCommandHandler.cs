using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GDC.Utilities;
using Yarn.Unity;

namespace GDC.Dialogue.Yarn
{
    /// <summary>
    /// 
    /// </summary>
    public class GameRoomCommandHandler : Singleton<GameRoomCommandHandler>
    {
        [SerializeField] private SpriteRenderer gameRoomCover;

        #region Public methods
        [YarnCommand("fade_in_roomcover")]
        public static void FadeInRoom(float duration)
        {
            Instance.StartCoroutine(Instance.FadeInRoomAnimation(duration));
        }



        [YarnCommand("fade_out_roomcover")]
        public static void FadeOutRoom(float duration)
        {
            Instance.StartCoroutine(Instance.FadeOutRoomAnimation(duration));
        }
        #endregion
        
        
        
        #region Private methods
        private IEnumerator FadeOutRoomAnimation(float duration)
        {
            float elapsedTime = 0f;
            Color originalColor = gameRoomCover.color;
            Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);

            while (elapsedTime < duration)
            {
                gameRoomCover.color = Color.Lerp(originalColor, targetColor, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            gameRoomCover.color = targetColor;
        }



        private IEnumerator FadeInRoomAnimation(float duration)
        {
            float elapsedTime = 0f;
            Color originalColor = gameRoomCover.color;
            Color targetColor = new Color(originalColor.r, originalColor.g, originalColor.b, 1f);

            while (elapsedTime < duration)
            {
                gameRoomCover.color = Color.Lerp(originalColor, targetColor, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            gameRoomCover.color = targetColor;
        }
        #endregion
    }
}
