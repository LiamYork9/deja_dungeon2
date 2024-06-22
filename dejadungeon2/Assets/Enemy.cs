using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform pathContainer;
    Vector3 startPos;
    int curWaypoint = 0;
    public Rigidbody2D rb;
    public float speed = 5f;

    private void Start()
    {
        startPos = transform.position;
    }

    private void FixedUpdate()
    {
        float frameSpeed = speed * Time.deltaTime;
        Vector3 targetPos = pathContainer.GetChild(curWaypoint).position;
        rb.MovePosition(Vector3.MoveTowards(rb.position, targetPos, frameSpeed));
        if (Vector3.Distance(rb.position, targetPos) <= 0.01f)
        {
            curWaypoint++;
            curWaypoint %= pathContainer.childCount;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("enemy collided with "+collision.name);
    }

    public void Reset()
    {
        transform.position = startPos;
    }
}
