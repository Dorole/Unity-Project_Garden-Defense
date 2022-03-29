using UnityEngine;
using TMPro;
using System;

namespace GardenDefense
{
    public class LivesDisplay : MonoBehaviour
    {//TODO potencijalno odvoji logiku od UI-a, tu i u StarsDisplay

        public static event Action onGameOver;

        [SerializeField] float _baseLives = 3;
        [SerializeField] int _damage = 1;
        
        float _lives;
        TextMeshProUGUI _livesText;

        private void Awake()
        {
            _livesText = GetComponent<TextMeshProUGUI>();
            _lives = _baseLives - PlayerPrefsController.GetDifficulty();
            UpdateLivesDisplay();
        }

        private void Start()
        {
            BaseCollider.onBaseReached += DecreaseLife;
        }

        private void DecreaseLife()
        {
            _lives -= _damage;
            UpdateLivesDisplay();

            if (_lives <= 0)
                onGameOver?.Invoke();
        }

        private void UpdateLivesDisplay() 
        {
            if (_lives >= 0)
                _livesText.text = _lives.ToString();  
            else
                _livesText.text = "0";
        }

        private void OnDisable()
        {
            BaseCollider.onBaseReached -= DecreaseLife;
        }
    }
}
