using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walking : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 playerVelocity; 
    public string storedDirection;
    //KeyEventArgs Input;

    // Start is called before the first frame update
    void Start()
    {
        playerVelocity = Vector2.zero;
        //storedDirection = "R";
    }

    // Update is called once per frame
    void Update()
    {
        playerVelocity.x = Input.GetAxisRaw("Horizontal");
        playerVelocity.y = Input.GetAxisRaw("Vertical");

        if(Input.GetKeyDown(KeyCode.A)) {
            storedDirection = "L";
        } 
        if((Input.KeyDown(KeyCode.S)) || (Input.KeyDown(KeyCode.Down))) {
            storedDirection = "D"
        } 
        /*if((Input.KeyDown(KeyCode.D)) || (Input.KeyDown(KeyCode.Right))) {
            //playerVelocity.x = 5;
            storedDirection = "R";
        } 
        if((Input.KeyDown(KeyCode.W)) || (Input.KeyDown(KeyCode.Up))) {
            //playerVelocity.y = 5;
            storedDirection = "U";
        }*/
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + playerVelocity * moveSpeed * Time.fixedDeltaTime);

        
    }
}
