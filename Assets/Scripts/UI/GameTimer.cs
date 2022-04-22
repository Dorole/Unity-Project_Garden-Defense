using System;
using UnityEngine;
using UnityEngine.UI;

namespace GardenDefense
{
    public class GameTimer : MonoBehaviour
    {
        public static event Action onTimerExpired;

        [Tooltip("Level timer in seconds")]
        [SerializeField] float _levelTime = 30f;

        float _startTime;
        bool _shouldWait = true;
        bool _timerFinished;

        private void Start()
        {
            if (!FindObjectOfType<CountdownTimer>()) //Debug only
                _shouldWait = false;
            else
                CountdownTimer.onCountdownFinished += ActivateTimer;

            GetComponent<Slider>().value = 0;
        }

        private void Update()
        {
            if (_timerFinished || _shouldWait) return;

            DecreaseTimer();

            if (_timerFinished)
                onTimerExpired?.Invoke();
        }

        void ActivateTimer() => _shouldWait = false;

        void DecreaseTimer()
        {
            _startTime += Time.deltaTime;
            GetComponent<Slider>().value = _startTime / _levelTime;

            _timerFinished = _startTime >= _levelTime;
        }

        private void OnDisable()
        {
            CountdownTimer.onCountdownFinished -= ActivateTimer;
        }

    }
}
