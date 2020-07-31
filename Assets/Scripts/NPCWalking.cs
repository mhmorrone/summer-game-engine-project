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
    public bool isDead = false;
    public bool enable = true;

    // Start is called before the first frame update
    void Start()
    {

    }


    void FixedUpdate()
    {
        if (!enable)
        {
            return;
        }
        if (!isDead)
        {
            if (counter == 0)
            {
                if (walk == 0)
                    walk = 1;
                else
                    walk = 0;
                counter = Random.Range(120, 300);
                walkDirection = Random.Range(0.0f, 2.0f * 3.14f);
                movement.x = Mathf.Cos(walkDirection) * moveSpeed;
                movement.y = Mathf.Sin(walkDirection) * moveSpeed;
            }
            else
            {
                counter--;
            }
            animator.SetFloat("IsWalking", walk);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Horizontal", movement.x);
            if (walk == 1)
            {
                rb2d.MovePosition(rb2d.position + movement * Time.fixedDeltaTime);
            }
        }
        


    }
}
