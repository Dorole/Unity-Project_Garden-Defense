using System;
using UnityEngine;

namespace GardenDefense
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BaseCollider : MonoBehaviour
    {
        public static event Action onBaseReached;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //would be best to check for interface or a script
            onBaseReached?.Invoke();
        }
    }
}
