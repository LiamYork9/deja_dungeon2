using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTurnOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.ResetEvent += ResetWall;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Collider2D>().enabled = false;
        }
    }
    private void ResetWall()
    {
        GetComponent<Collider2D>().enabled = true;
    }
}
