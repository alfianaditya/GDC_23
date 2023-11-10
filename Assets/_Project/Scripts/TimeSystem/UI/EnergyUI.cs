using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using GDC.Utilities;
using Unity.VisualScripting;

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
        private void Awake()
        {
            energyText.text = "0 %";
            energyBar.fillAmount = 0f;
        }



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
            if (evt.IsRising)
            {
                OnEnergyRise(evt.Energy);
            }

            else
            {
                OnEnergyFall(evt.Energy);
            }
        }



        private void OnEnergyRise(int energyAmount)
        {
            StartCoroutine(NumberRiseAnimation(energyAmount, 0.5f));
            
            float amount = energyAmount / TimeManager.MAX_ENERGY;

            StartCoroutine(FillAnimation(amount, 0.5f));
        }



        private void OnEnergyFall(int energyAmount)
        {
            StartCoroutine(NumberFallAnimation(energyAmount, 0.5f));
            
            float amount = energyAmount / TimeManager.MAX_ENERGY;

            StartCoroutine(FillAnimation(amount, 0.5f));
        }



        private IEnumerator FillAnimation(float fillAmount, float speed = 1f)
        {
            float currentFillAmount = energyBar.fillAmount;
            float time = 0f;

            while (time < 1f)
            {
                time += Time.deltaTime * speed;
                energyBar.fillAmount = Mathf.Lerp(currentFillAmount, fillAmount, time);
                yield return null;
            }
        }



        private IEnumerator LeakAnimation(float speed = 1f)
        {
            float time = 0f;

            while (time < 1f)
            {
                time += Time.deltaTime * speed;
                energyBar.fillAmount = Mathf.Lerp(energyBar.fillAmount, 0f, time);
                yield return null;
            }
        }



        private IEnumerator NumberRiseAnimation(int number, float speed = 1f)
        {
            float time = 0f;

            while (time < 1f)
            {
                time += Time.deltaTime * speed;
                energyText.text = Mathf.RoundToInt(Mathf.Lerp(0, number, time)).ToString() + " %";
                yield return null;
            }
        }



        private IEnumerator NumberFallAnimation(int number, float speed = 1f)
        {
            float time = 0f;

            while (time < 1f)
            {
                time += Time.deltaTime * speed;
                energyText.text = Mathf.RoundToInt(Mathf.Lerp(number, 0, time)).ToString() + " %";
                yield return null;
            }
        }
        #endregion
    }
}
