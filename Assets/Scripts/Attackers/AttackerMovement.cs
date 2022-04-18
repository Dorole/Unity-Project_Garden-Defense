using UnityEngine;

namespace GardenDefense
{
    public class AttackerMovement : MonoBehaviour
    {
        [HideInInspector] public bool wasRepelled;
        float _currentSpeed = 1f;
 
        void Update()
        {
            transform.Translate(Vector2.left * _currentSpeed * Time.deltaTime);
        }

        public void SetMovementSpeed(float speed)
        {
            _currentSpeed = speed;
        }

        private void OnBecameInvisible()
        {
            if (wasRepelled)
            {
                transform.localScale = new Vector2(1, 1);
                wasRepelled = false;
            }

            ObjectPooler.instance.ReturnToPool(gameObject.tag, gameObject);
        }
    }
}
