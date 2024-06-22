using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public bool auto = false; //do projectiles fire automatically?
    public float delay = 0.5f; //time between projectile firings
    float lastFired = 0; //last time projectile was fired
    public GameObject prefab;
    public float angle = 0f; //angle projectiles are fired
    public float spread = 0f; //random angle deviation
    public int angleChange = 0; //amount of times angle should change
    public float angleChangeAmount = 15f;
    public bool angleChangeReverseBehavior = false; //should angle change direction reverse when it hits amount of angle changes to make
    int angleChangeCount = 0;
    float angleChangeOffset = 0f;
    int angleChangeReverse = 1;

    Queue<GameObject> pool = new Queue<GameObject>();
    public int preload = 10; //amount of projectiles to preload into the pool

    private void Start()
    {
        for (int i = 0; i < preload; i++) CreateAndPoolPrefab();
    }

    void CreateAndPoolPrefab()
    {
        GameObject obj = Instantiate(prefab);
        obj.AddComponent<ReturnToObjectPool>().pool = pool;
        obj.SetActive(false); //ReturnToObjectPool will handle enqueueing the object
    }

    GameObject GetFromPool() { 
        if (pool.Count == 0) CreateAndPoolPrefab();
        return pool.Dequeue(); 
    }

    private void FixedUpdate()
    {
        if (auto && Time.time > lastFired + delay) Fire();
    }

    void Fire()
    {
        GameObject obj = GetFromPool();
        Projectile projectile = obj.GetComponent<Projectile>();
        obj.transform.eulerAngles = transform.eulerAngles + new Vector3(0,0, angle + angleChangeOffset + Random.Range(-spread, spread));
        obj.transform.position = transform.position;
        obj.SetActive(true);
        projectile.Fired();
        if (angleChange > 0)
        {
            angleChangeCount += 1 * angleChangeReverse;
            angleChangeOffset = angleChangeCount * angleChangeAmount;
            if (angleChangeCount > angleChange)
            {
                if (angleChangeReverseBehavior)
                {
                    angleChangeCount = angleChange - 1;
                    angleChangeReverse = -1;
                } else
                {
                    angleChangeCount = 0;
                }
            }
            else if (angleChangeCount == -1) //only happens if we were reversing in the first place
            {
                angleChangeCount = 1;
                angleChangeReverse = 1;
            }
        }
        lastFired = Time.time;
    }
}
