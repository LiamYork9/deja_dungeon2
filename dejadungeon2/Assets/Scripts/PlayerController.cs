using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 facing = Vector2.right;
    public bool tryInteract = false;
    public LayerMask interactMask;
    public float interactLength = 0.6f;

    public Animator animator;

    void FixedUpdate()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.MovePosition(rb.position + moveInput.normalized * Time.deltaTime * moveSpeed);
        //Get direction we are facing based on move input
        if (moveInput.magnitude > 0)
        {
            if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
            {
                facing = moveInput.x < 0 ? Vector2.left : Vector2.right;
                animator.SetInteger("Facing", moveInput.x < 0 ? 2 : 1);
            }
            else 
            {
                facing = moveInput.y < 0 ? Vector2.down : Vector2.up;
                animator.SetInteger("Facing", moveInput.y < 0 ? 0 : 3);
            }
        }

        //Interact with whatever is in front of the player
        if (tryInteract)
        {
            tryInteract = false;
            RaycastHit2D hit = Physics2D.Raycast(rb.position, facing, interactLength, interactMask.value);
            if (hit.collider != null)
            {
                hit.collider.GetComponent<Interactable>()?.Interact(facing);
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
