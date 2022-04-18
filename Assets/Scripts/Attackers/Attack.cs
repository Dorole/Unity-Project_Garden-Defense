using UnityEngine;

namespace GardenDefense
{
    public class Attack : MonoBehaviour
    {
        //use only on attackers with an attacking animation

        GameObject _currentTarget;
        Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            UpdateAnimationState();
        }

        public void HandleAttack(GameObject target)
        {
            _animator.SetBool("IsAttacking", true);
            _currentTarget = target;
        }

        private void UpdateAnimationState()
        {
            if (!_currentTarget || !_currentTarget.activeSelf)
                _animator.SetBool("IsAttacking", false); 
        }

        public void StrikeCurrentTarget(int damage)
        {
            if (!_currentTarget || !_currentTarget.activeSelf)
                return;

            Health health = _currentTarget.GetComponent<Health>();
            if (health)
                health.HandleDamage(damage);
        }
    }
}
