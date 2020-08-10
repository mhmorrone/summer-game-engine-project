using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairs : MonoBehaviour
{
    public GameObject StairsLanding;
    //private int distance = 1000;

    /*
     * TODO:Find a way to distinguish between the two floors
     *      OR
     *      Make the "distance" or perhaps some other determining
     *      variable belong to the player or maybe even the building
     *      in order to determine which direction to teleport the player.
     *      
     *      Another possibility is to move the teleportation code into
     *      the Player GameObject and store a variable like that.
     */
    void OnTriggerEnter2D(Collider2D col)
    {
        //character or object is transported to the connected stairs landing of the other floor when they enter the stairs
        col.gameObject.transform.Translate(StairsLanding.transform.position - col.gameObject.transform.position);
    }
}
