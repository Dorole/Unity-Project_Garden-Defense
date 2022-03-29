using System;
using UnityEngine;

namespace GardenDefense
{
    public class DefenderSpawner : MonoBehaviour
    {
        public static event Action<int> onDefenderPurchased;

        Defender _defender;
        StarsDisplay _starsDisplay;

        private void Start()
        {
            _starsDisplay = FindObjectOfType<StarsDisplay>();
        }

        private void OnMouseDown()
        {
            AttemptPlaceDefenderAt(GetSquareClicked());
        }

        private void AttemptPlaceDefenderAt(Vector2 gridPos)
        {
            int defenderCost = _defender.Cost;

            if (_starsDisplay.HaveEnoughStars(defenderCost))
            {
                SpawnDefender(gridPos);
                onDefenderPurchased?.Invoke(defenderCost);
            }
        }

        private Vector2 GetSquareClicked()
        {
            Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
            Vector2 gridPos = SnapToGrid(worldPos);
            return gridPos;
        }

        private Vector2 SnapToGrid(Vector2 rawWorldPos)
        {
            float roundedX = Mathf.RoundToInt(rawWorldPos.x);
            float roundedY = Mathf.RoundToInt(rawWorldPos.y);
            return new Vector2(roundedX, roundedY);
        }

        public void SetSelectedDefender(Defender selectedDefender)
        {
            _defender = selectedDefender;
        }

        void SpawnDefender(Vector2 spawnPoint)
        {
            if (!_defender)
            {
                Debug.Log("No defender selected!");
                return;
            }
            ObjectPooler.instance.SpawnFromPool(_defender.tag, spawnPoint, Quaternion.identity);
        }
    }
}
