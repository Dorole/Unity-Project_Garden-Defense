using System;
using System.Collections.Generic;
using UnityEngine;

namespace GardenDefense
{
    public class Repellent : MonoBehaviour
    {
        public static event Action onRepellerReached;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Lizard") || collision.gameObject.CompareTag("Fox")) //way to refactor?
                onRepellerReached?.Invoke();
        }
    }
    
}
