using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalking : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float walk = 0f;
    public float moveSpeed = 1.0f;
    public float walkDirection = 0;
    public int counter = 0;
    public Vector2 movement;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }


    void FixedUpdate()
    {
        if (counter == 0)
        {
            if (walk == 0)
                walk = 1;
            else
                walk = 0;
            counter = Random.Range(120, 300);
            walkDirection = Random.Range(0.0f, 2.0f * 3.14f);
            animator.SetFloat("IsWalking", walk);
            movement.x = Mathf.Cos(walkDirection) * moveSpeed;
            animator.SetFloat("Horizontal", movement.x);
            movement.y = Mathf.Sin(walkDirection) * moveSpeed;
            animator.SetFloat("Vertical", movement.y);
        }
        else
        {
            counter--;
        }


        if (walk == 1)
        {
            rb2d.MovePosition(rb2d.position + movement * Time.fixedDeltaTime);
        }


    }
}
