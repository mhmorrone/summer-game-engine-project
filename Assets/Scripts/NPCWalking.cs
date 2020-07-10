using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalking : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public bool walk = false;
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
            walk = !walk;
            counter = Random.Range(120, 300);
            walkDirection = Random.Range(0.0f, 2.0f * 3.14f);
            animator.SetFloat("Direction", (walkDirection * 180.0f / 3.14f));
            animator.SetBool("IsWalking", walk);
            movement.x = Mathf.Cos(walkDirection) * moveSpeed;
            movement.y = Mathf.Sin(walkDirection) * moveSpeed;
        }
        else
        {
            counter--;
        }


        if (walk == true)
        {
            rb2d.MovePosition(rb2d.position + movement * Time.fixedDeltaTime);
        }


    }
}
