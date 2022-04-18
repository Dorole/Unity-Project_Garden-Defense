using UnityEngine;

namespace GardenDefense
{
    public class Repellent : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Lizard") || collision.gameObject.CompareTag("Fox")) 
                SendAttackerBack(collision.gameObject);
        }

        void SendAttackerBack(GameObject go)
        {
            go.GetComponent<Animator>().SetTrigger("RepellentReached");
            go.transform.localScale = new Vector2(-1, 1);
            go.GetComponent<AttackerMovement>().wasRepelled = true;
        }
    }
    
}
