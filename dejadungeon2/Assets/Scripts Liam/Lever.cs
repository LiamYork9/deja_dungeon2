using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

           
        }

    }

  



    private void BridgeReset()
    {
        this.spriteRenderer.enabled = false;
       
    }
}
