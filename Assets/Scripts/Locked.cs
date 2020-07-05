using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locked : MonoBehaviour
{
    public bool isLocked = true;
    public Transform trans;
    public LayerMask playerLayers;
    public float range = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Collider2D[] players = Physics2D.OverlapCircleAll(trans.position, range, playerLayers);
            if (players[0] != null)
            {
               isLocked = !isLocked; 
            }
            
        }

    }
}
