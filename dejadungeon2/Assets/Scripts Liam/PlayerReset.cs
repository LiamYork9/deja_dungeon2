using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            Respawn();
        }
    }

    void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        transform.position = startPos;
    }
}
