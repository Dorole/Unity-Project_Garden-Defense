using System;
using UnityEngine;
using UnityEngine.UI;

namespace GardenDefense
{
    public class GameTimer : MonoBehaviour
    {
        public static event Action onTimerExpired; //potencijalno zaustavi animaciju

        [Tooltip("Level timer in seconds")]
        [SerializeField] float _levelTime = 30f;
        bool _timerFinished;

        private void Update()
        {
            if (_timerFinished)
                return;

            GetComponent<Slider>().value = Time.timeSinceLevelLoad / _levelTime;
            _timerFinished = (Time.timeSinceLevelLoad >= _levelTime);

            if (_timerFinished)
            {
                onTimerExpired?.Invoke();
            }
        }
    }
}
