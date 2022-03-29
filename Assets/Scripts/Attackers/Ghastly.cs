using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GardenDefense
{
    public class Ghastly : MonoBehaviour, IAttacker
    {
        [SerializeField] SpriteRenderer _spriteRend;
        [SerializeField] Color _ghostlyColor;
        Color _normalColor;

        private void Start()
        {
            _normalColor = _spriteRend.color;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            _spriteRend.color = _ghostlyColor;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _spriteRend.color = _normalColor;
        }
    }
}
