using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using Yarn.Unity;
using Unity.VisualScripting;
using GDC.Core;
using GDC.Utilities;

namespace GDC.Dialogue.Yarn
{
    /// <summary>
    /// 
    /// </summary>
    public class DialogueWindowView: DialogueViewBase
    {
        [SerializeField] private TextMeshProUGUI dialogue;
        [SerializeField] private TextMeshProUGUI character;
        private int choiceIndex = 0;
        private Action advanceHandler = null;
        private Coroutine currentCoroutine;

        #region MonoBehaviour methods
        private void Update()
        {
            GetInput();
        }
        #endregion



        #region Public methods
        public override void DialogueStarted()
        {
            OnDialogue evt = new OnDialogue(true);
            EventManager.Broadcast(evt);
        }



        public override void DialogueComplete()
        {
            advanceHandler = null;
            OnDialogue evt = new OnDialogue(false);
            EventManager.Broadcast(evt);
        }



        public override void UserRequestedViewAdvancement()
        {
            advanceHandler?.Invoke();
        }



        public override void RunLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
        {
            if (dialogue.gameObject.activeInHierarchy == false)
            {
                onDialogueLineFinished();
                return;
            }

            float typeDelay;
            GameManager.VariableStorage.TryGetValue("$type_delay", out typeDelay);

            character.text = dialogueLine.CharacterName;

            currentCoroutine = StartCoroutine(TypeText(dialogueLine.TextWithoutCharacterName.Text, typeDelay));
            advanceHandler = requestInterrupt;
        }



        public override void RunOptions(DialogueOption[] dialogueOptions, Action<int> onOptionSelected)
        {
            if (dialogue.gameObject.activeInHierarchy == false)
            {
                return;
            }

            character.text = "";

            DialogueWindowUICommandHandler.OpenChoices(new List<string> { dialogueOptions[0].Line.Text.Text, dialogueOptions[1].Line.Text.Text });

            advanceHandler = () =>
            {
                advanceHandler = null;
                onOptionSelected(choiceIndex);
                choiceIndex = 0;
                DialogueWindowUICommandHandler.SetChoiceIndex(choiceIndex);

                DialogueWindowUICommandHandler.CloseChoices();
            };
        }



        public override void InterruptLine(LocalizedLine dialogueLine, Action onDialogueLineFinished)
        {
            if (dialogue.gameObject.activeInHierarchy == false)
            {
                onDialogueLineFinished();
                return;
            }

            advanceHandler = null;

            if (currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
                dialogue.text = dialogueLine.TextWithoutCharacterName.Text;
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
            if (dialogue.gameObject.activeInHierarchy == false)
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
        #endregion



        #region Private methods
        private void GetInput()
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                UserRequestedViewAdvancement();
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                choiceIndex--;
                if (choiceIndex < 0)
                {
                    choiceIndex = 0;
                }

                DialogueWindowUICommandHandler.SetChoiceIndex(choiceIndex);
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                choiceIndex++;
                if (choiceIndex > 1)
                {
                    choiceIndex = 1;
                }

                DialogueWindowUICommandHandler.SetChoiceIndex(choiceIndex);
            }
        }



        private IEnumerator TypeText(string text, float delay)
        {
            string currentText = "";

            foreach (char letter in text)
            {
                currentText += letter;
                dialogue.text = currentText;

                float punctuationDelayMultiplier;
                GameManager.VariableStorage.TryGetValue("$punctuation_delay_multiplier", out punctuationDelayMultiplier);

                if (letter == '.' || letter == ',' || letter == '!' || letter == '?')
                {
                    yield return new WaitForSeconds(delay * punctuationDelayMultiplier);
                }

                else
                {
                    yield return new WaitForSeconds(delay);
                }
            }

            currentCoroutine = null;
        }
        #endregion
    }
}
