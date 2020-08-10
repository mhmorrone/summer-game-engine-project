using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Locked : MonoBehaviour
{
    public bool isLocked = true;
    public Transform trans;
    public LayerMask playerLayers;
    public float range = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            //door is locked or unlocked when L key is pressed when player is close to the door
            Collider2D[] players = Physics2D.OverlapCircleAll(trans.position, range, playerLayers);
            if (players != null && players.Length > 0 && (players[0].transform.position - trans.position).magnitude < range)
            {
                isLocked = !isLocked;
            }

        }

    }
}
