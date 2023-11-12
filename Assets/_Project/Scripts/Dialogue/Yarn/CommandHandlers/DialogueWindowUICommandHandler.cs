using System.Collections;
using System.Collections.Generic;
using Yarn.Unity;
using UnityEngine;
using GDC.Utilities;
using UnityEngine.UI;
using TMPro;

namespace GDC.Dialogue.Yarn
{
    /// <summary>
    /// Yarn command handler for the dialogue window UI.
    /// </summary>
    public class DialogueWindowUICommandHandler : Singleton<DialogueWindowUICommandHandler>
    {
        [SerializeField] private GameObject dialogueWindow;
        [SerializeField] private Image dialogueWindowImage;
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private GameObject choices;
        [SerializeField] private List<TextMeshProUGUI> choiceTexts = new List<TextMeshProUGUI>();
        private float originalChoiceTextSize;
        private int choiceIndex = 0;
        private Vector3 originalScale;

        #region MonoBehaviour methods
        protected override void Awake()
        {
            base.Awake();

            originalChoiceTextSize = choiceTexts[0].fontSize;
            originalScale = dialogueWindow.transform.localScale;
        }
        #endregion



        #region Public methods
        [YarnCommand("open_window")]
        public static void OpenWindow()
        {
            Instance.dialogueWindow.SetActive(true);
            Instance.StartCoroutine(Instance.WindowPopUp(0.1f, 0.1f));
        }



        [YarnCommand("close_window")]
        public static void CloseWindow()
        {
            Instance.StartCoroutine(Instance.WindowFadeOut(0.2f));
            Instance.StartCoroutine(Instance.TextFadeOut(0.2f));
        }



        [YarnCommand("erase_text")]
        public static void EraseText()
        {
            Instance.dialogueText.text = "";
        }



        public static void OpenChoices(List<string> choices)
        {
            EraseText();
            
            Instance.choices.SetActive(true);

            foreach (TextMeshProUGUI choiceText in Instance.choiceTexts)
            {
                choiceText.text = choices[Instance.choiceTexts.IndexOf(choiceText)];
            }

            Instance.choices.SetActive(true);
        }



        public static void CloseChoices()
        {
            Instance.choices.SetActive(false);
        }



        public static void SetChoiceIndex(int index)
        {
            Instance.choiceIndex = index;

            foreach (TextMeshProUGUI choiceText in Instance.choiceTexts)
            {
                choiceText.fontSize = Instance.originalChoiceTextSize;
            }

            Instance.choiceTexts[Instance.choiceIndex].fontSize = Instance.originalChoiceTextSize * 1.5f;
        }
        #endregion



        #region Private methods
        private IEnumerator WindowPopUp(float duration, float scale = 1f)
        {
            dialogueWindowImage.color = Color.white;

            float time = 0f;
            while (time < duration)
            {
                time += Time.deltaTime;
                dialogueWindow.transform.localScale = Vector3.Lerp(originalScale, originalScale + new Vector3(scale, scale, scale), time / duration);
                yield return null;
            }

            time = 0f;
            while (time < duration)
            {
                time += Time.deltaTime;
                dialogueWindow.transform.localScale = Vector3.Lerp(originalScale + new Vector3(scale, scale, scale), originalScale, time / duration);
                yield return null;
            }
        }



        private IEnumerator WindowFadeOut(float duration)
        {
            float elapsedTime = 0f;
            Color startColor = dialogueWindowImage.color;
            Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

            while (elapsedTime < duration)
            {
                dialogueWindowImage.color = Color.Lerp(startColor, endColor, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            dialogueWindowImage.color = endColor;

            dialogueWindow.SetActive(false);
        }



        private IEnumerator TextFadeOut(float duration)
        {
            float elapsedTime = 0f;
            Color startColor = dialogueText.color;
            Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

            while (elapsedTime < duration)
            {
                dialogueText.color = Color.Lerp(startColor, endColor, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            dialogueText.color = startColor;
            dialogueText.text = "";
        }
        #endregion
    }
}
