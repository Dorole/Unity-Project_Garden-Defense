using System.Collections;
using UnityEngine;

namespace GardenDefense
{
    public class Spawner : MonoBehaviour
    {
        bool _canSpawn = true;
        [SerializeField] GameObject[] _spawnableObjects;
        [SerializeField] float _minSpawnDelay = 1f;
        [SerializeField] float _maxSpawnDelay = 5f;
        Coroutine _spawningCO;

        private void Start()
        {
            _spawningCO = StartCoroutine(CO_SpawnAttacker());
            GameTimer.onTimerExpired += StopSpawningAttackers;
        }

        IEnumerator CO_SpawnAttacker()
        {
            while (_canSpawn)
            {
                float randomSpawnTime = Random.Range(_minSpawnDelay, _maxSpawnDelay);
                yield return new WaitForSeconds(randomSpawnTime);
                
                Spawn();
            }
        }

        void Spawn()
        {
            int randomAttackerIndex = Random.Range(0, _spawnableObjects.Length);
            ObjectPooler.instance.SpawnFromPool(_spawnableObjects[randomAttackerIndex].tag, 
                                                 transform.position, Quaternion.identity, 
                                                 true, transform);
        }

        void StopSpawningAttackers()
        {
            StopCoroutine(_spawningCO);
        }

        private void OnDisable()
        {
            GameTimer.onTimerExpired -= StopSpawningAttackers;
        }
    }
}
