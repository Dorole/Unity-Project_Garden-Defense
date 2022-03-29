using UnityEngine;
using TMPro;

namespace GardenDefense
{
    public class StarsDisplay : MonoBehaviour
    {
        [SerializeField] int _baseStars = 500;
        [SerializeField] int _starsModifier = 200;
        int _stars;
        TextMeshProUGUI _starsText;

        private void Start()
        {
            _starsText = GetComponent<TextMeshProUGUI>();
            SetStartingStarsAmount();
            UpdateDisplay();

            DefenderSpawner.onDefenderPurchased += SpendStars;
            Defender.onStarsProduced += AddStars;
            Health.onEnemyKilled += AddStars;
        }

        private void SetStartingStarsAmount()
        {
            switch (PlayerPrefsController.GetDifficulty())
            {
                case 0:
                    _stars = _baseStars + _starsModifier;
                    break;
                case 1:
                    _stars = _baseStars;
                    break;
                case 2:
                    _stars = _baseStars - _starsModifier;
                    break;
            }
        }

        public void AddStars(int amount)
        {
            if (PlayerPrefsController.GetDifficulty() == 0)
                _stars += amount;
            else
                _stars += amount / 2;
            UpdateDisplay();
        }

        public void SpendStars(int amount)
        {
            if (_stars >= amount && _stars-amount >= 0)
            {
                _stars -= amount;
                UpdateDisplay();
            }
        }

        public bool HaveEnoughStars(int amount) => (_stars-amount) >= 0;

        private void UpdateDisplay()
        {
            _starsText.text = _stars.ToString(); 
        }

        private void OnDisable()
        {
            DefenderSpawner.onDefenderPurchased -= SpendStars;
            Defender.onStarsProduced -= AddStars;
            Health.onEnemyKilled -= AddStars;
        }
    }
}
