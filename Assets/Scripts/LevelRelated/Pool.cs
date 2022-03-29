using UnityEngine;

namespace GardenDefense
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public Transform parent;
        public int size;
    }
}
