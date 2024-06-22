using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector2 dir;
    public float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("collided with "+collision.name);
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(dir.x, dir.y) * speed * Time.deltaTime;
    }
}
