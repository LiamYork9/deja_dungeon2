using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToObjectPool : MonoBehaviour
{
    public Queue<GameObject> pool;
    private void OnDisable()
    {
        pool.Enqueue(gameObject);
    }
}
