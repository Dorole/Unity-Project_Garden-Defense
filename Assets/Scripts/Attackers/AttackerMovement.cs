using UnityEngine;

namespace GardenDefense
{
    public class AttackerMovement : MonoBehaviour
    {
        float _currentSpeed = 1f;
        GameObject _currentTarget;
        Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            transform.Translate(Vector2.left * _currentSpeed * Time.deltaTime);
            UpdateAnimationState();
        }

        public void SetMovementSpeed(float speed)
        {
            _currentSpeed = speed;
        }

        private void OnBecameInvisible()
        {
            ObjectPooler.instance.ReturnToPool(gameObject.tag, gameObject);
        }

        public void Attack(GameObject target)
        {
            _animator.SetBool("IsAttacking", true);
            _currentTarget = target;
        }

        private void UpdateAnimationState()
        {
            if (!_currentTarget || !_currentTarget.activeSelf)
                _animator.SetBool("IsAttacking", false); //move attack to another class, observer
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
