using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2 : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Collider2D Bridge;
    public Collider2D block;
    public Collider2D block2;


    void Start()
    {
        EventManager.ResetEvent += BridgeReset;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            spriteRenderer.enabled = true;
            block.enabled = false;
            Bridge.enabled = false;
            block2.enabled = false;
            
           




        }

    }

    private void BridgeReset()
    {
        spriteRenderer.enabled = false;
        block.enabled = true;
        Bridge.enabled = true;
        block2.enabled = true;
    }
}
