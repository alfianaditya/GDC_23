using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using GDC.Utilities;

namespace GDC.TimeSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class EnergyUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI energyText;
        [SerializeField] private Image energyBar;

        #region MonoBehaviour methods
        private void OnEnable()
        {
            EventManager.AddListener<OnEnergyChanged>(OnEnergyChanged);
        }



        private void OnDisable()
        {
            EventManager.RemoveListener<OnEnergyChanged>(OnEnergyChanged);
        }
        #endregion
        
        
        
        #region Private methods
        private void OnEnergyChanged(OnEnergyChanged evt)
        {
            energyText.text = evt.Energy.ToString() + " %";
            energyBar.fillAmount = (float)evt.Energy / TimeManager.MAX_ENERGY;
        }
        #endregion
    }
}
