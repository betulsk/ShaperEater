using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ObjectPooler;

public class ObjectPooler : Singleton<ObjectPooler>
{
    [System.Serializable]
    public class Pool
    {
        public string Tag;
        public GameObject Prefab;
        public int Size;
    }

    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;
    void Start()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            PoolDictionary.Add(pool.Tag, objectPool);
        }
    }

    public GameObject Pop(string tag, Vector3 position, Quaternion rotation)
    {
        if (!PoolDictionary.ContainsKey(tag))
        {
            return null;
        }
        GameObject objectToSpawn = PoolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        PoolDictionary[tag].Enqueue(objectToSpawn);
        return objectToSpawn;
    }

    public void Push(GameObject obj)
    {
        obj.SetActive(false);
    }
}
