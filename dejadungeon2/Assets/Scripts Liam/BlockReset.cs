using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockReset : MonoBehaviour
{
    Vector2 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        EventManager.ResetEvent += BlockReturn;
    }

    // Update is called once per frame
    private void BlockReturn()
    {
        transform.position = startPos;
    }
}
