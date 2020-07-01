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
    public float range = 0.5f;
    public LayerMask playerLayers;

   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Collider2D[] players = Physics2D.OverlapCircleAll(trans.position, range, playerLayers);
            if(players != null)
            {
                if (!locked.isLocked)
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
