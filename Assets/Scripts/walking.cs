﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 playerVelocity; 
    public string storedDirection;

    // Start is called before the first frame update
    void Start()
    {
        playerVelocity = Vector2.zero;
        storedDirection = "D";
    }

    // Update is called once per frame
    void Update()
    {
        playerVelocity.x = Input.GetAxisRaw("Horizontal");
        playerVelocity.y = Input.GetAxisRaw("Vertical");

        if(playerVelocity.x < 0) {
            storedDirection = "L";
        } 
        if(playerVelocity.y < 0) {
            storedDirection = "D";
        } 
        if(playerVelocity.x > 0) {
            storedDirection = "R";
        } 
        if(playerVelocity.y > 0) {
            storedDirection = "U";
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + playerVelocity * moveSpeed * Time.fixedDeltaTime);

        
    }
}
