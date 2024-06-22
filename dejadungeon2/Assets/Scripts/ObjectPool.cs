using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    Queue<GameObject> pool = new Queue<GameObject>();
    public int preload = 10; //amount of projectiles to preload into the pool
    List<GameObject> inUse = new List<GameObject>();
    public GameObject prefab;
    private void Start()
    {
        for (int i = 0; i < preload; i++) CreateAndPoolPrefab();
    }

    void CreateAndPoolPrefab()
    {
        GameObject obj = Instantiate(prefab);
        obj.AddComponent<ReturnToObjectPool>().pool = this;
        obj.SetActive(false); //ReturnToObjectPool will handle enqueueing the object
    }

    public GameObject GetFromPool()
    {
        if (pool.Count == 0) CreateAndPoolPrefab();
        GameObject obj = pool.Dequeue();
        inUse.Add(obj);
        //print(inUse.Count);
        return obj;
    }

    public void ReturnAll()
    {
        List<GameObject> cur = new List<GameObject>(inUse); //Object is deactivated when going through list, so to avoid list being changed need to make copy of list
        for (int i = 0; i < cur.Count; i++)
        {
            cur[i].SetActive(false);
        }
        inUse.Clear();
    }

    public void Return(GameObject obj)
    {
        inUse.Remove(obj);
        pool.Enqueue(obj);
    }
}
