using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Enemy : MonoBehaviour
{
    public Transform pathContainer;
    Vector3 startPos;
    int curWaypoint = 0;
    public Rigidbody2D rb;
    public float speed = 5f;
    Vector2 targetPos;

    public Animator animator;

    private void Start()
    {
        startPos = transform.position;
        EventManager.ResetEvent += Reset;
        targetPos = pathContainer.GetChild(curWaypoint).position;
    }

    private void FixedUpdate()
    {
        float frameSpeed = speed * Time.deltaTime;
        rb.MovePosition(Vector3.MoveTowards(rb.position, targetPos, frameSpeed));
        if (Vector2.Distance(rb.position, targetPos) <= 0.01f)
        {
            curWaypoint++;
            curWaypoint %= pathContainer.childCount;
            targetPos = pathContainer.GetChild(curWaypoint).position;
            Vector2 dir = (targetPos - rb.position);
            if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
            {
                animator.SetInteger("Facing", dir.x < 0 ? 2 : 1);
            }
            else
            {
                animator.SetInteger("Facing", dir.y < 0 ? 0 : 3);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("enemy collided with "+collision.name);
    }

    public void Reset()
    {
        rb.transform.position = startPos;
        curWaypoint = 0;
        targetPos = pathContainer.GetChild(curWaypoint).position;
    }
}
