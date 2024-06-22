using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToObjectPool : MonoBehaviour
{
    public ObjectPool pool;
    private void OnDisable()
    {
        pool.Return(gameObject);
    }
}
