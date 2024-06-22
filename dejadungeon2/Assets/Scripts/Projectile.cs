using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("collided with "+collision.name);
    }

    void FixedUpdate()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
