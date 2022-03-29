using System.Collections;
using System.Collections.Generic;
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

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _renderer.color = _inactiveColor;
            _spawner = FindObjectOfType<DefenderSpawner>();
        }

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
    }
}
