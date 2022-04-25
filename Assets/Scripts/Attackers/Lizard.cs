using UnityEngine;

namespace GardenDefense
{
    public class Lizard : MonoBehaviour, IAttacker
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Defender>()
                && !collision.gameObject.CompareTag("Scarecrow"))
            {
                GetComponent<Attack>().HandleAttack(collision.gameObject);
            }
        }
    }
}
