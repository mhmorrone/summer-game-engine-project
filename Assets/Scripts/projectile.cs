using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float bulletSpeed = 15f;
    public Rigidbody2D rb;
    public Rigidbody2D pr;
    Vector2 playerVelocity; 
    Vector2 projectileVelocity;
    public string storedDirection;
    //KeyEventArgs Input;

    // Start is called before the first frame update
    void Start()
    {
        playerVelocity = Vector2.zero;
        storedDirection = "R";
    }

    // Update is called once per frame
    void Update()
    {
        playerVelocity.x = Input.GetAxisRaw("Horizontal");
        playerVelocity.y = Input.GetAxisRaw("Vertical");

        if (playerVelocity.x>0 && playerVelocity.y==0) {
            storedDirection = "R";
        }
        if (playerVelocity.x<0 && playerVelocity.y==0) {
            storedDirection = "L";
        }
        if (playerVelocity.x==0 && playerVelocity.y>0) {
            storedDirection = "U";
        }
        if (playerVelocity.x==0 && playerVelocity.y<0) {
            storedDirection = "D";
        }
        if (playerVelocity.x>0 && playerVelocity.y>0) {
            storedDirection = "UR";
        }
        if (playerVelocity.x<0 && playerVelocity.y>0) {
            storedDirection = "UL";
        }
        if (playerVelocity.x>0 && playerVelocity.y<0) {
            storedDirection = "DR";
        }
        if (playerVelocity.x<0 && playerVelocity.y<0) {
            storedDirection = "DL";
        }
        if (playerVelocity.x==0 && playerVelocity.y==0) {
            storedDirection = storedDirection;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + playerVelocity * moveSpeed * Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.F)) {
            if (storedDirection.Equals("R")) {
                projectileVelocity.x = 1;
                projectileVelocity.y = 0;
            }
            else if (storedDirection.Equals("L")) {
                projectileVelocity.x = -1;
                projectileVelocity.y = 0;
            }
            else if (storedDirection.Equals("U")) {
                projectileVelocity.x = 0;
                projectileVelocity.y = 1;
            }
            else if (storedDirection.Equals("D")) {
                projectileVelocity.x = 0;
                projectileVelocity.y = -1;
            }
            else if (storedDirection.Equals("UR")) {
                projectileVelocity.x = 1;
                projectileVelocity.y = 1;
            }
            else if (storedDirection.Equals("UL")) {
                projectileVelocity.x = -1;
                projectileVelocity.y = 1;
            }
            else if (storedDirection.Equals("DR")) {
                projectileVelocity.x = 1;
                projectileVelocity.y = -1;
            }
            else if (storedDirection.Equals("DL")) {
                projectileVelocity.x = -1;
                projectileVelocity.y = -1;
            }
            pr.MovePosition(pr.position + projectileVelocity * bulletSpeed * Time.fixedDeltaTime);
        }
    }
}
