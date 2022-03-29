using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GardenDefense
{
    public class Shooter : MonoBehaviour
    {
        ObjectPooler _objectPooler;
        Spawner[] _attackerSpawners;
        Spawner _thisLaneSpawner;
        [SerializeField] GameObject _projectile;
        Animator _anim; //consider another class

        private void Start()
        {
            _objectPooler = ObjectPooler.instance;
            _attackerSpawners = FindObjectsOfType<Spawner>();
            _anim = GetComponent<Animator>();
            SetLaneSpawner();
        }

        private void Update()
        {
            if (IsAttackerInLane())
                _anim.SetBool("IsAttacking", true);
            else
                _anim.SetBool("IsAttacking", false);
        }

        public void Shoot()
        {
            _objectPooler.SpawnFromPool(_projectile.tag, transform.position, Quaternion.identity);
        }

        private void SetLaneSpawner()
        {
            foreach (var spawner in _attackerSpawners)
            {
                bool isCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon;
                if (isCloseEnough)
                    _thisLaneSpawner = spawner;
            }
        }

        private bool IsAttackerInLane()
        {
            if (!_thisLaneSpawner)
                return false;

            return _thisLaneSpawner.gameObject.GetComponentsInChildren<AttackerMovement>().GetLength(0) >= 1;
        }
    }
}