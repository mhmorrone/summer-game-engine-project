using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locked : MonoBehaviour
{
    public bool isLocked = false;
    public Collider2D door;


    // Update is called once per frame
    void Update()
    {
        if (isLocked)
        {
            door.enabled = true;
        }
        else
        {
            door.enabled = false;
        }

    }
}
