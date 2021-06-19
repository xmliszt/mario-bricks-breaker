using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterPooler : MonoBehaviour
{
    public enum ItemType
    {
        coin = 0,
        highSpeed = 1,
        shrink = 2,
    }

    [System.Serializable]
    public class Pool {
        public ItemType type;
        public GameObject poolItem;
        public int capacity; // size of the pool
    }

    public List<Pool> pools;
    public Dictionary<ItemType, Queue<GameObject>> poolerRepository;
    void Awake()
    {
        poolerRepository = new Dictionary<ItemType, Queue<GameObject>>();
        foreach (Pool pool in pools)
        {
            Queue<GameObject> itemPool = new Queue<GameObject>();
            for (int i = 0; i < pool.capacity; i ++)
            {
                GameObject item = Instantiate(pool.poolItem);
                item.SetActive(false);
                itemPool.Enqueue(item);
            }
            poolerRepository.Add(pool.type, itemPool);
        }
    }

    public GameObject SpawnItem(ItemType tag, Vector3 position, Quaternion rotation)
    {
        Queue<GameObject> pool = poolerRepository[tag];
        GameObject item = pool.Dequeue();
        item.transform.position = position;
        item.transform.rotation = rotation;
        return item;
    }

    public void RecycleItem(ItemType tag, GameObject gameObject)
    {
        poolerRepository[tag].Enqueue(gameObject);
    }
}
