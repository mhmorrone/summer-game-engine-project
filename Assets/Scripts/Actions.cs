using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public bool follow = true;
    public Transform trans;
    public NPCWalking walkScript;
    public bool isDead = false;
    public LayerMask characterLayers;
    public float attackRange = 1f;
    public int damage = 5;


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (follow)
                Follow();
            if (Input.GetKeyDown(KeyCode.T))
            {
                walkScript.movement.x = 0;
                walkScript.movement.y = 0;
                walkScript.walk = 0;
                Talk();
            }
        }
        
    }

    //Follow player - activate when part of the group for the player
    public void Follow(float range = 10f)
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players != null)
        {
            if ((players[0].transform.position - trans.position).magnitude > range)
            {
                if (players[0].transform.position.x - trans.position.x < 0)
                    walkScript.movement.x = -1 * walkScript.moveSpeed;
                else if (players[0].transform.position.x - trans.position.x > 0)
                    walkScript.movement.x = 1 * walkScript.moveSpeed;
                else
                    walkScript.movement.x = 0;
                if (players[0].transform.position.y - trans.position.y < 0)
                    walkScript.movement.y = -1 * walkScript.moveSpeed;
                else if (players[0].transform.position.y - trans.position.y > 0)
                    walkScript.movement.y = 1 * walkScript.moveSpeed;
                else
                    walkScript.movement.y = 0;
                walkScript.walk = 1;
            }

        }
    }

    //Fight
    public void Fight()
    {
        Collider2D[] hitCharacters = Physics2D.OverlapCircleAll(trans.position, attackRange, characterLayers);
        foreach(Collider2D character in hitCharacters)
        {
            character.GetComponent<Health>().TakeDamage(damage);
        }
    }

    //Move NPC to certain place
    public void Move()
    {

    }

    //Talk to player
    public void Talk()
    {
        //walkScript.enable = false;
        //Display dialogue and have interactable elements
        //walkScript.enable = true;
        //Debug.Log("Hi");
    }

    //Can place other actions for NPCs here (such as trade, fighting, etc.)
    //Has potential to activate these functions through buttons available in dialogue or as a result of certain actions
}
