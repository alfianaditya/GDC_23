using System.Collections;
using System.Collections.Generic;
using GDC.Misc;
using GDC.Utilities;
using UnityEngine;
using Yarn.Unity;

namespace GDC.Core
{
    /// <summary>
    /// Manages game overall.
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        private InMemoryVariableStorage variableStorage;
        public static InMemoryVariableStorage VariableStorage { get { return Instance.variableStorage;} }
        private DialogueRunner dialogueRunner;
        public static DialogueRunner DialogueRunner { get { return Instance.dialogueRunner;} }
        [SerializeField] private Transform player;
        [SerializeField] private Transform playerStartPoint;

        #region MonoBehaviour methods
        private void Start()
        {
            variableStorage = GameObject.FindObjectOfType<InMemoryVariableStorage>();
            dialogueRunner = GameObject.FindObjectOfType<DialogueRunner>();

            BeginGame();
        }
        #endregion
        
        
        
        #region Public methods
        public static void ResetPosition()
        {
            Instance.player.position = Instance.playerStartPoint.position;
        }
        #endregion



        #region Private methods
        private void BeginGame()
        {
            FadeBlack.FullBlack();
            dialogueRunner.StartDialogue("Start");
        }
        #endregion
    }
}
