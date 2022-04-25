using System;
using UnityEngine;

namespace GardenDefense
{
    public class Golem : MonoBehaviour, IAttacker
    {
        public static event Action<int> onGolemAttack;
        public static event Action onGolemDeployed;
        public static event Action onGolemDestroyed;

        [SerializeField] int _damage = 999;
        [SerializeField] int _starsDepleted = 100;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if (health)
                health.HandleDamage(_damage);

            onGolemAttack?.Invoke(_starsDepleted);
        }

        private void OnBecameVisible()
        {
            onGolemDeployed?.Invoke();
        }

        private void OnBecameInvisible()
        {
            onGolemDestroyed?.Invoke();
        }
    }
}
