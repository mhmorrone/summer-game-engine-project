using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Cryptography;
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
    Transform character;
    Rigidbody2D rb;
    int counter;
    public float distance;
    Vector2 target;
    public Vector2 newPos;
    Collider2D[] enemies;
    float temp;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player").transform;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
        enemies = Physics2D.OverlapCircleAll(trans.position, 100, characterLayers);
        distance = temp = 1000;
        foreach (Collider2D enemy in enemies)
        {
            temp = Vector2.Distance(enemy.transform.position, trans.position);
            if(temp < distance)
            {
                distance = temp;
                character = enemy.transform;
            }
        }
        trans.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        //trans.GetComponent<Rigidbody2D>().velocity.y = 0;
        counter -= 1;
        if (!isDead)
        {            
            animator.SetFloat("Distance", distance);
            if(follow && distance < 1000 && character != null)
            {
                walkScript.enable = false;
                Follow(character);
            }
            else
            {
                walkScript.enable = true;
            }
            
                
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
    public void Follow(Transform point = null)
    {
        if(point == null)
        {
            point = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if(counter <= 0)
        {
            counter = 10;
            //target = new Vector2(player.transform.position.x + UnityEngine.Random.Range(-1f, 1f), player.transform.position.y + UnityEngine.Random.Range(-5f, 5f));
            target = new Vector2(point.position.x, point.position.y);
            animator.SetFloat("Vertical", (target.y - trans.position.y) * 100);
            animator.SetFloat("Horizontal", (target.x - trans.position.x) * 100);
        }
        newPos = Vector2.MoveTowards(trans.position, target, walkScript.moveSpeed * Time.fixedDeltaTime);
        animator.SetFloat("IsWalking", 1);
        trans.GetComponent<Rigidbody2D>().MovePosition(newPos);
    }

    //Fight
    public void Fight(bool isZombie = false)
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
            if (isZombie)
            {
                character.GetComponent<Health>().zombieChance += 1;
            }
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
    public void Move(Transform point)
    {
        //Makes use of the Follow Function to move the NPC to a certain spot instead of towards the player
        Follow(point);
        counter = (int)Mathf.Ceil(Vector2.Distance(target, trans.position)/Vector2.Distance(Vector2.MoveTowards(trans.position, target, walkScript.moveSpeed * Time.fixedDeltaTime), trans.position));
        for(; counter > 0; counter--)
        {
            Follow(point);
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
