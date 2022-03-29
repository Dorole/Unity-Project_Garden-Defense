using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GardenDefense
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float _speed = 3;
        [SerializeField] int _damage = 1;
        ObjectPooler _objectPooler;

        private void Start()
        {
            _objectPooler = ObjectPooler.instance;
        }

        private void Update()
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IAttacker isAttacker = collision.GetComponent<IAttacker>();
            Health attackerHealth = collision.GetComponent<Health>();

            if (isAttacker != null && attackerHealth != null)
            {
                attackerHealth.HandleDamage(_damage); //observer?
                _objectPooler.ReturnToPool(gameObject.tag, gameObject);
            }
            else
                return;
            
        }

        private void OnBecameInvisible()
        {
            _objectPooler.ReturnToPool(gameObject.tag, gameObject);
        }
    }
}
