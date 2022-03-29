using System.Collections.Generic;
using UnityEngine;

namespace GardenDefense
{
    public class ObjectPooler : MonoBehaviour
    {
        public static ObjectPooler instance;

        public List<Pool> pools;
        public Dictionary<string, Queue<GameObject>> poolDictionary;

        #region Singleton
        private void Awake()
        {
            instance = this;
        }
        #endregion

        private void Start()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();
            FillPools();
        }

        private void FillPools()
        {
            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectQueue = new Queue<GameObject>();

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject o = Instantiate(pool.prefab);
                    o.transform.parent = pool.parent;
                    o.SetActive(false);
                    objectQueue.Enqueue(o);
                }

                poolDictionary.Add(pool.tag, objectQueue);
            }
        }

        private void ExpandEmptyPool(string tag)
        {
            Pool pool = pools.Find(item => item.tag == tag);
            pool.size++; 
            GameObject o = Instantiate(pool.prefab);
            o.transform.parent = pool.parent;
            o.SetActive(false);
            poolDictionary[tag].Enqueue(o);
        }

        public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, 
                                        bool overrideParent = false, Transform newParent = null) 
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
                return null;
            }

            if (poolDictionary[tag].Count <= 0)
                ExpandEmptyPool(tag);

            GameObject o = poolDictionary[tag].Dequeue();
            o.SetActive(true);
            o.transform.position = position;
            o.transform.rotation = rotation;
            if (overrideParent)
                o.transform.parent = newParent;

            return o;
        }

        public void ReturnToPool(string tag, GameObject objectToReturn)
        {
            poolDictionary[tag].Enqueue(objectToReturn);
            objectToReturn.SetActive(false); 
        }
    }
}
