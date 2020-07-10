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
            Collider2D[] players = Physics2D.OverlapCircleAll(trans.position, range, playerLayers);
            if (players != null)
            {
                if ((players[0].transform.position - trans.position).magnitude < range)
                {
                    isLocked = !isLocked;
                }
                
            }

        }
        isLocked = !isLocked;

    }
}
