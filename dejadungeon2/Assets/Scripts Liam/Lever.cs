using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lever : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public SpriteRenderer spriteDoor;
    public Collider2D TheOtherCollider;
    public Collider2D Bridge;
    public Collider2D TheOtherCollider2;
    public Collider2D Door;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.ResetEvent += BridgeReset;
      
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
                this.spriteRenderer.enabled = true;
                TheOtherCollider.enabled = false;
                 Bridge.enabled = false;
                TheOtherCollider2.enabled  = false;
                Door.enabled = false;
                this.spriteDoor.enabled = false;





        }

    }

  



    private void BridgeReset()
    {
        this.spriteRenderer.enabled = false;
        TheOtherCollider.enabled = true;
        Bridge.enabled = true;
        TheOtherCollider2.enabled = true;
        Door.enabled = true;
        this.spriteDoor.enabled = true;

    }
}
