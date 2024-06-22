using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 facing = Vector2.right;
    public bool tryInteract = false;
    public LayerMask interactMask;

    void FixedUpdate()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.MovePosition(rb.position + moveInput.normalized * Time.deltaTime * moveSpeed);
        //Get direction we are facing based on move input
        if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
        {
            facing = moveInput.x < 0 ? Vector2.left : Vector2.right;
        } else facing = moveInput.y < 0 ? Vector2.down : Vector2.up;

        //Interact with whatever is in front of the player
        if (tryInteract)
        {
            tryInteract = false;
            RaycastHit2D hit = Physics2D.Raycast(rb.position, facing, 2f, interactMask.value);
            if (hit.collider != null)
            {
                print("hit "+hit.collider.name);
            }
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            tryInteract=true;
        }
    }
}
