using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Rendering;

namespace UnityEngine.Experimental.Rendering.Universal
{
    public class OpenCloseDoor : MonoBehaviour
    {
        public Locked locked;
        public bool open = false;
        public Transform trans;
        public GameObject DoorHinge;
        public LayerMask playerLayers;
        public float range = 10f;
        public LightInsideBuilding light;

        float timer = 0f;

        // Update is called once per frame
        void Update()
        {
            timer -= Time.deltaTime;
            if (timer <= 0 && Input.GetKeyDown(KeyCode.C))
            {
                if (!locked.isLocked)
                {
                    Collider2D[] players = Physics2D.OverlapCircleAll(trans.position, range, playerLayers);
                    if (players != null)
                    {
                        if ((players[0].transform.position - trans.position).magnitude < range)
                        {
                            timer = 1f;
                            open = !open;
                            if (open)
                            {
                                trans.RotateAround(DoorHinge.transform.position, Vector3.forward, -90);
                                light.turnLightOn();
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
    }
}

