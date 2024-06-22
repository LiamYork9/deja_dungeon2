using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumblingFloor : MonoBehaviour
{
    public string state = "Stable";
    public string baseState = "Stable";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (state == "Stable")
        {
            state = "Falling";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
