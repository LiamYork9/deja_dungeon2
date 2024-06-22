using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.ResetEvent += BridgeReset;
      this.spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.spriteRenderer.enabled = true;
            GetComponent<Collider2D>().enabled = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        transform.position = new Vector3(0f, 2f, 0f);
    }


    private void BridgeReset()
    {
        this.spriteRenderer.enabled = false;
        GetComponent<Collider2D>().enabled = true;
    }
}
