using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float decayTime = 5f;
    float spawnTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("collided with "+collision.name);
    }

    public void Fired()
    {
        spawnTime = Time.time;
    }

    void FixedUpdate()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        if (spawnTime + decayTime < Time.time ) gameObject.SetActive(false);
    }
}
