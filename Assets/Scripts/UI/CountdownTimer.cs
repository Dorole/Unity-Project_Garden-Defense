using System;
using System.Collections;
using UnityEngine;
using TMPro;

namespace GardenDefense
{
    public class CountdownTimer : MonoBehaviour
    {
        public static event Action onCountdownFinished;

        [SerializeField] int _countdownTime;
        [SerializeField] TextMeshProUGUI _countdownDisplay;
        [SerializeField] string _startText = "Go!";


        private void Awake()
        {
            StartCoroutine(CO_CountdownToStart());
        }

        IEnumerator CO_CountdownToStart()
        {
            while (_countdownTime > 0)
            {
                _countdownDisplay.text = _countdownTime.ToString();
                yield return new WaitForSeconds(1f);
                _countdownTime--;
            }

            _countdownDisplay.text = _startText;
            yield return new WaitForSeconds(1f);
            gameObject.SetActive(false);

            onCountdownFinished?.Invoke();
        }
    }
}
