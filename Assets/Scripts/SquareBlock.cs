using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GardenDefense
{
    public class SquareBlock : MonoBehaviour
    {
        [SerializeField] float _minX, _maxX;
        [SerializeField] float _minY, _maxY;
        [Space]
        [SerializeField] int _numberOfBlockers = 3;
        [SerializeField] GameObject _blockingObject;

        private void Start()
        {
            for (int i = 0; i < _numberOfBlockers; i++)
            {
                Vector2 newRandomPos = GetRandomPosition();
                SpawnBlocker(newRandomPos);
            }
        }

        private Vector2 GetRandomPosition()
        {
            float randomX = Random.Range(_minX, _maxX);
            float randomY = Random.Range(_minY, _maxY);

            Vector2 gridPos = SnapToGrid(new Vector2(randomX, randomY));
            return gridPos;
        }

        private Vector2 SnapToGrid(Vector2 rawRandomPos)
        {
            float roundedX = Mathf.RoundToInt(rawRandomPos.x);
            float roundedY = Mathf.RoundToInt(rawRandomPos.y);
            return new Vector2(roundedX, roundedY);
        }

        void SpawnBlocker(Vector2 spawnPoint)
        {
            Instantiate(_blockingObject, spawnPoint, Quaternion.identity);
        }
    }
}
