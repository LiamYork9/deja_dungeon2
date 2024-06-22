using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovableObject : MonoBehaviour
{
    public bool moving;
    public Vector2 destination;
    public float elapsed;
    public Rigidbody2D rb;

    public void Shove(Vector2 dir)
    {
        if (moving) return;
        destination = transform.position + new Vector3(dir.x, dir.y);
        RaycastHit2D[] hits = new RaycastHit2D[2];
        if (Physics2D.BoxCast(transform.position, Vector2.one *.9f, 0f, dir, new ContactFilter2D(), hits, 1f) > 1) return;
        moving = true;
        elapsed = 0;
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            elapsed += Time.deltaTime;
            rb.MovePosition(Vector2.Lerp(transform.position, destination, elapsed));
            if (elapsed >= 1) { 
                moving = false;
            }
        }
    }
}
