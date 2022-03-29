using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GardenDefense
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] Slider _healthBar;
        Health _damageableObject;

        private void Start()
        {
            _damageableObject = GetComponent<Health>();
            _healthBar.maxValue = _damageableObject.MaxHealth;
            _healthBar.value = _healthBar.maxValue;
        }

        private void Update()
        {
            if (_damageableObject.CurrentHealth != _healthBar.value)
                _healthBar.value = _damageableObject.CurrentHealth;
        }
    }
}
