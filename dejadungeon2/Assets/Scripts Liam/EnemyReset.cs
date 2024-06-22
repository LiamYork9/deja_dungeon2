using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyReset : MonoBehaviour
{
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        EventManager.ResetEvent += EnemyReturn;
    }

    // Update is called once per frame
    private void EnemyReturn()
    {
        transform.position = startPos;
        
    }
}
