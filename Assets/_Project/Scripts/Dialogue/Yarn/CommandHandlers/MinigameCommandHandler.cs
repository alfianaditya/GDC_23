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
    public class MinigameCommandHandler : Singleton<MinigameCommandHandler>
    {
        [SerializeField] private GameObject wateringMinigame;

        
        [YarnCommand("start_watering_minigame")]
        public static void StartWateringMinigame()
        {
            Instance.wateringMinigame.SetActive(true);
        }

        

        public static void StopWateringMinigame()
        {
            Instance.wateringMinigame.SetActive(false);
        }
    }
}
