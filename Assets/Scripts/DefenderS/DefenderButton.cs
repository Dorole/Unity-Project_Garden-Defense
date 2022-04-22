using UnityEngine;

namespace GardenDefense
{
    public class DefenderButton : MonoBehaviour
    {
        SpriteRenderer _renderer;
        [SerializeField] Color _inactiveColor;
        Color _activeColor = Color.white;

        [SerializeField] Defender _defender;
        DefenderSpawner _spawner;
        BoxCollider2D _collider;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _renderer.color = _inactiveColor;

            _spawner = FindObjectOfType<DefenderSpawner>();

            if (FindObjectOfType<CountdownTimer>()) 
            {
                _collider = GetComponent<BoxCollider2D>();
                _collider.enabled = false;
                CountdownTimer.onCountdownFinished += EnableCollider;
            }    
        }

        void EnableCollider() => _collider.enabled = true;

        private void OnMouseDown()
        {
            SetUnusedButtonsColor();
            _renderer.color = _activeColor;
            _spawner.SetSelectedDefender(_defender);
        }

        void SetUnusedButtonsColor()
        {
            var buttons = FindObjectsOfType<DefenderButton>();
            foreach (var button in buttons)
            {
                button.GetComponent<SpriteRenderer>().color = _inactiveColor;
            }
        }

        private void OnDisable()
        {
            CountdownTimer.onCountdownFinished -= EnableCollider;
        }
    }
}
