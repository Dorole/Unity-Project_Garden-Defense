using System;
using System.Collections.Generic;
using UnityEngine;

namespace GardenDefense
{
    public class Health : MonoBehaviour
    {
        public static event Action<int> onEnemyKilled;

        [SerializeField] int _maxHealth = 50;
        [SerializeField] GameObject _effect; //move to separate script, observer, pool?
        [SerializeField] int _starsReward = 10;
        int _currentHealth;
        public int CurrentHealth => _currentHealth;
        public int MaxHealth => _maxHealth;
        AttackerMovement _attacker;

        private void Awake()
        {
            _currentHealth = _maxHealth;
            _attacker = GetComponent<AttackerMovement>();
            if (!_attacker)
                return;
        }

        public void HandleDamage(int damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                if (_attacker)
                    onEnemyKilled?.Invoke(_starsReward);

                PlayDeathEffect();
                ObjectPooler.instance.ReturnToPool(gameObject.tag, gameObject);
                _currentHealth = _maxHealth;
            }
        }

        private void PlayDeathEffect()
        {
            if (!_effect)
            {
                Debug.LogWarning("There is no death effect on " + gameObject.name);
                return;
            }

            GameObject effect = Instantiate(_effect, transform.position, Quaternion.identity);
            Destroy(effect, 1);
        }
    }
}
