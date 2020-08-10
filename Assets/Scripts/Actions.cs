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
    public Transform trans; //NPC transform
    public NPCWalking walkScript;
    public bool isDead = false;
    public LayerMask characterLayers; //layers that the NPC can attack.
    public float attackRange = 1f;
    public int damage = 5;
    public Vector3 attackOffset;
    public Animator animator;
    Transform character;
    Rigidbody2D rb;
    int counter;
    public float distance; //distance to closest character it can attack. Used for following functions and such
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
        //Calculates distance to closest character it can attack and stores the distance and which character it is
        enemies = Physics2D.OverlapCircleAll(trans.position, 100, characterLayers);
        distance = temp = 1000;
        foreach (Collider2D enemy in enemies)
        {
            if (!enemy.GetComponent<Health>().isDead)
            {
                temp = Vector2.Distance(enemy.transform.position, trans.position);
                if (temp < distance)
                {
                    distance = temp;
                    character = enemy.transform;
                }
            }
        }
        //Sets velocity to 0 each update so that other characters cannot push the NPC very far and unrealistically
        trans.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        
        counter -= 1; //counter for the follow function
        if (!isDead)
        {            
            animator.SetFloat("Distance", distance);
            if(follow && distance < 1000 && character != null)
            {
                //follow a specific character
                walkScript.enable = false;
                Follow(character);
            }
            else
            {
                //if NPC is not following a character, they move randomly instead
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

    //Follow a specified character
    public void Follow(Transform point = null)
    {
        if(point == null)
        {
            point = GameObject.FindGameObjectWithTag("Player").transform;
        }
        if(counter <= 0)
        {
            counter = 10; //target only changes every 10 updates so that the NPC does not look like it is glitching due to the rapidly changing animations
            target = new Vector2(point.position.x, point.position.y);
            animator.SetFloat("Vertical", (target.y - trans.position.y) * 100);
            animator.SetFloat("Horizontal", (target.x - trans.position.x) * 100);
        }
        //NPC moves closer to target each update
        newPos = Vector2.MoveTowards(trans.position, target, walkScript.moveSpeed * Time.fixedDeltaTime);
        animator.SetFloat("IsWalking", 1);
        trans.GetComponent<Rigidbody2D>().MovePosition(newPos);
    }

    //Fight - NPC attacks whoever is within range
    public void Fight(bool isZombie = false)
    {
        follow = false;
        animator.SetFloat("IsWalking", 0);//NPC should not be walking
        //Offset the attack slightly for better results
        Vector3 pos = trans.position;
        pos.x += distance * 0.5f * walkScript.movement.x/Math.Abs(walkScript.movement.x);
        pos.y += distance * 0.5f * walkScript.movement.y / Math.Abs(walkScript.movement.y);

        Collider2D[] hitCharacters = Physics2D.OverlapCircleAll(trans.position, attackRange, characterLayers);
        foreach(Collider2D character in hitCharacters)
        {
            //have each hit character that is able to take attacks from the NPC take damage
            character.GetComponent<Health>().TakeDamage(damage);
            if (isZombie)
            {
                //if the NPC is a zombie, the hit character's chance of becoming a zombie increases
                character.GetComponent<Health>().zombieChance += 2; 
            }
        }
    }

    //Run away - a possible result of being hit
    public void Flight()
    {
        walkScript.enable = true;
        walkScript.walk = 1;
        walkScript.counter = 500;
        //walkScript.moveSpeed *= 2;
    }

    //NPC stands still - a possible result of being hit
    public void Freeze()
    {
        walkScript.enable = true;
        walkScript.walk = 0;
        walkScript.counter = 500;
    }


    //Move NPC to certain place
    //It currently is not used anywhere, but could be useful in future methods in combination with player ordering NPCs in their group to do certain tasks
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
