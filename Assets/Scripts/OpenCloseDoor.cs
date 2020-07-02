using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class OpenCloseDoor : MonoBehaviour
{
    public Locked locked;
    public bool open = false;
    public Transform trans;
    public GameObject DoorHinge;
    public LayerMask playerLayers;
    public float range = 5f;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(!locked.isLocked)
            {
                Collider2D[] players = Physics2D.OverlapCircleAll(trans.position, range, playerLayers);
                if(players[0] != null)
                {
                    open = !open;
                    if (open)
                    {
                        trans.RotateAround(DoorHinge.transform.position, Vector3.forward, -90);
                    }
                    else
                    {
                        trans.RotateAround(DoorHinge.transform.position, Vector3.forward, 90);
                    }
                }
                
            }
        }
        
    }
}
