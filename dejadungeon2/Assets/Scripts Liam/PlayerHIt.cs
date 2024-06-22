using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHIt : MonoBehaviour
{
    RaycastHit2D hit;

    // Update is called once per frame
    void Update()
    {
        hit=Physics2D.Raycast(transform.position, Vector2.right);
        Debug.Log(hit.collider);
    }
}
