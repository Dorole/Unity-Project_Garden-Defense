using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GardenDefense
{
    public class Fox : MonoBehaviour, IAttacker
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Gravestone"))
                GetComponent<Animator>().SetTrigger("JumpTrigger");

            else if (collision.gameObject.GetComponent<Defender>())
                GetComponent<AttackerMovement>().Attack(collision.gameObject);
        }
    }
}
