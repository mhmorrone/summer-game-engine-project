using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public CharacterController controller;
    public Rigidbody2D rb;
    public float movespeed = 5f;
    Vector2 movement;
    

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        
    }

    void FixedUpdate()
    {
        //Move character
        //controller.Move(movement.x * movespeed * Time.fixedDeltaTime, movement.y * movespeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
    }
}
