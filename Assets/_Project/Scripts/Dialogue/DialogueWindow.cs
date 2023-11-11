using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using Yarn.Unity;
using Unity.VisualScripting;
using GDC.Core;

namespace GDC.Dialogue
{
    /// <summary>
    /// 
    /// </summary>
    public class DialogueWindow : DialogueViewBase
    {
        [SerializeField] private TextMeshProUGUI dialogue;
        private Action advanceHandler = null;
        private Coroutine currentCoroutine;

        #region MonoBehaviour methods
        private void Update()
        {
            GetInput();
        }
        #endregion



        #region Public methods
        public override void UserRequestedViewAdvancement()
        {
            advanceHandler?.Invoke();
        }



        public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
        {
            if (gameObject.activeInHierarchy == false)
            {
                onDialogueLineFinished();
                return;
            }

            float typeDelay;
            GameManager.VariableStorage.TryGetValue("$type_delay", out typeDelay);

            currentCoroutine = StartCoroutine(TypeText(dialogueLine.Text.Text, typeDelay));
            advanceHandler = requestInterrupt;
        }



        public override void InterruptLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
        {
            if (gameObject.activeInHierarchy == false)
            {
                onDialogueLineFinished();
                return;
            }

            advanceHandler = null;

            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
                dialogue.text = dialogueLine.Text.Text;
                currentCoroutine = null;

                advanceHandler = requestInterrupt;
            }

            else
            {
                onDialogueLineFinished();
            }
        }



        public override void DismissLine(Action onDismissalComplete)
        {
            if (gameObject.activeInHierarchy == false)
            {
                onDismissalComplete();
                return;
            }

            advanceHandler = () =>
            {
                advanceHandler = null;
                onDismissalComplete();
            };

            advanceHandler = null;
            onDismissalComplete();
        }



        [YarnCommand("mengontols")]
        public static void Mengontols()
        {
            Debug.Log("Mengontols");
        }
        #endregion



        #region Private methods
        private void GetInput()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                UserRequestedViewAdvancement();
            }
        }



        private IEnumerator TypeText(string text, float delay)
        {
            string currentText = "";

            foreach (char letter in text)
            {
                currentText += letter;
                dialogue.text = currentText;
                yield return new WaitForSeconds(delay);
            }

            currentCoroutine = null;
        }
        #endregion
    }
}
