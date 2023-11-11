using System.Collections;
using System.Collections.Generic;
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

        #region MonoBehaviour methods
        private void Start()
        {
            variableStorage = GameObject.FindObjectOfType<InMemoryVariableStorage>();
            dialogueRunner = GameObject.FindObjectOfType<DialogueRunner>();
        }
        #endregion
        
        
        
        #region Private methods
        
        #endregion
    }
}
