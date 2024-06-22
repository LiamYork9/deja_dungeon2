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
        EventManager.ResetEvent+= TileReset;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
        if (state == "Stable")
        {
            state = "Falling";
        }
        else if (state == "Falling")
        {
            
            Debug.Log("Die");
        }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
        if (state == "Falling")
        {
            state = "Fallen";
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        }
    }

    

    public void TileReset()
    {
        state = "Stable";
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
