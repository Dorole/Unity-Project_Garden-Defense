using System.Collections;
using System;
using UnityEngine;

namespace GardenDefense
{
    public class LevelEndController : MonoBehaviour
    {
        public static event Action onLevelEnded;

        int _activeAttackersNum;

        private void Start()
        {
            GameTimer.onTimerExpired += StartCountingDownAttackers;
        }

        void StartCountingDownAttackers()
        {
            StartCoroutine(CO_TrackActiveAttackers());
        }
        
        int FindActiveAttackers()
        {
            AttackerMovement[] _attackers = FindObjectsOfType<AttackerMovement>(false);
            Debug.Log(_attackers.Length);
            return _attackers.Length;
        }

        IEnumerator CO_TrackActiveAttackers()
        {
            do
            {
                _activeAttackersNum = FindActiveAttackers();
                yield return new WaitForSeconds(1);

            } while (_activeAttackersNum > 0);
            Debug.Log("Level ended");
            onLevelEnded?.Invoke();
        }

        private void OnDisable()
        {
            GameTimer.onTimerExpired -= StartCountingDownAttackers;
        }
    }
}
