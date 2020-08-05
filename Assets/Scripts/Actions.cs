using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
//using System.Media;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public bool follow = true;
    public Transform trans;
    public NPCWalking walkScript;
    public bool isDead = false;
    public LayerMask characterLayers;
    public float attackRange = 5f;
    public int damage = 5;
    public Vector3 attackOffset;
    public Animator animator;
    GameObject player;
    Rigidbody2D rb;
    int counter;
    public float distance;
    Vector2 target;
    public Vector2 newPos;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        trans.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        //trans.GetComponent<Rigidbody2D>().velocity.y = 0;
        counter -= 1;
        if (!isDead)
        {
            distance = Vector2.Distance(player.transform.position, trans.position);
            animator.SetFloat("Distance", distance);
            if (follow)
                Follow();
                
            /*if (Input.GetKeyDown(KeyCode.T))
            {
                walkScript.movement.x = 0;
                walkScript.movement.y = 0;
                walkScript.walk = 0;
                Talk();
            }*/
        }
        
    }

    //Follow player - activate when part of the group for the player
    public void Follow()
    {
        if(counter <= 0)
        {
            counter = 10;
            //target = new Vector2(player.transform.position.x + UnityEngine.Random.Range(-1f, 1f), player.transform.position.y + UnityEngine.Random.Range(-5f, 5f));
            target = new Vector2(player.transform.position.x, player.transform.position.y);
            animator.SetFloat("Vertical", (target.y - trans.position.y) * 100);
            animator.SetFloat("Horizontal", (target.x - trans.position.x) * 100);
        }
        newPos = Vector2.MoveTowards(trans.position, target, walkScript.moveSpeed * Time.fixedDeltaTime);
        animator.SetFloat("IsWalking", 1);
        trans.GetComponent<Rigidbody2D>().MovePosition(newPos);
    }

    //Fight
    public void Fight()
    {
        follow = false;
        animator.SetFloat("IsWalking", 0);
        Vector3 pos = trans.position;
        pos.x += distance * 0.5f * walkScript.movement.x/Math.Abs(walkScript.movement.x);
        pos.y += distance * 0.5f * walkScript.movement.y / Math.Abs(walkScript.movement.y);

        Collider2D[] hitCharacters = Physics2D.OverlapCircleAll(trans.position, attackRange, characterLayers);
        foreach(Collider2D character in hitCharacters)
        {
            character.GetComponent<Health>().TakeDamage(damage);
        }
    }

    //Run away
    public void Flight()
    {
        walkScript.enable = true;
        walkScript.walk = 1;
        walkScript.counter = 500;
        //walkScript.moveSpeed *= 2;
    }

    //NPC stands still
    public void Freeze()
    {
        walkScript.enable = true;
        walkScript.walk = 0;
        walkScript.counter = 500;
    }


    //Move NPC to certain place
    public void Move(Vector2 targ)
    {
        //Makes use of the Follow Function to move the NPC to a certain spot instead of towards the player
        target = targ;
        counter = (int)Mathf.Ceil(Vector2.Distance(targ, trans.position)/Vector2.Distance(Vector2.MoveTowards(trans.position, target, walkScript.moveSpeed * Time.fixedDeltaTime), trans.position));
        for(; counter > 0; counter--)
        {
            Follow();
        }
    }

    //Talk to player
    //public void Talk()
    //{
        //walkScript.enable = false;
        //Display dialogue and have interactable elements
        //walkScript.enable = true;
        //Debug.Log("Hi");
    //}

    //Can place other actions for NPCs here (such as trade, fighting, etc.)
    //Has potential to activate these functions through buttons available in dialogue or as a result of certain actions
}
