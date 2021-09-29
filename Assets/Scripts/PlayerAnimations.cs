using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private PlayerInput input;
    private TestPlayerMovement movement; // this needs to be changed when final product
    private Rigidbody2D rb2d;
    
    
    void Start()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<PlayerInput>();
        movement = GetComponent<TestPlayerMovement>(); // this needs to be changed when final product
        rb2d = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {

        if (input.moveVector.x != 0)
        {
            transform.localScale = new Vector2(input.moveVector.x, 1f); // this will flip the player sprite to have it face the direction it is running
        }
        
        if (movement.IsGrounded())
        {
            if (input.moveVector.x != 0)
            {
                animator.Play("Run");
            }
            else
            {
                animator.Play("Idle");
            }
        }
        else
        {
            if (rb2d.velocity.y > 0)
            {
                animator.Play("Jump");
            }
            else
            {
                animator.Play("fall");
            }
        }

        if (input.attack)
        {
            animator.Play("Attack");
        }
        
    }
}
