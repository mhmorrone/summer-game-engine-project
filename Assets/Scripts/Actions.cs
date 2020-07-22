using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public bool follow = true;
    public Transform trans;
    public float range = 10f;
    public NPCWalking walkScript;


    // Start is called before the first frame update
    void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
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

    //Follow player - activate when part of the group for the player
    void Follow()
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

    //Move NPC to certain place
    void Move()
    {

    }

    //Talk to player
    void Talk()
    {
        //walkScript.enable = false;
        //Display dialogue and have interactable elements
        //walkScript.enable = true;
    }

    //Can place other actions for NPCs here (such as trade, fighting, etc.)
    //Has potential to activate these functions through buttons available in dialogue or as a result of certain actions
}
