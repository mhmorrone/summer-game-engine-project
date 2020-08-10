using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movespeed = 5f;
    Vector2 movement;
    public Animator animator;
    public bool enable = true;


    // Update is called once per frame
    void Update()
    {
        if (!enable) // disabled when dead
        {
            return;
        }
        //receives input from arrow key or aswd keys
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //sets animator parameters based on input so that animation reflects movement
        animator.SetFloat("Speed", movement.sqrMagnitude);
        if(movement.sqrMagnitude != 0)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
        
        
    }

    void FixedUpdate()
    {
        //Move character based on input
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
    }
}
