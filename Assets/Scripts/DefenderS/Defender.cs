using System;
using System.Collections.Generic;
using UnityEngine;

namespace GardenDefense
{
    public class Defender : MonoBehaviour
    {
        public static event Action<int> onStarsProduced;

        [SerializeField] int _cost = 100;
        public int Cost => _cost;

        public void AddStars(int amount) 
        {
            //FindObjectOfType<StarsDisplay>().AddStars(amount); 
            onStarsProduced?.Invoke(amount);
        }
    }
}
