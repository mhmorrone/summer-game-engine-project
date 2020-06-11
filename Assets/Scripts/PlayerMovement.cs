using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float runspeed = 40f;
    float horizontalMove = 0f;
    float verticalMove = 0f;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runspeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runspeed;

        //Move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime);
    }

    //void FixedUpdate()
    //{
       // controller.Move(verticalMove * Time.fixedDeltaTime, false, false);
    //}
}
