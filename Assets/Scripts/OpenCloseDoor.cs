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
            /*The door opens or closes when the C key is pressed down and the player is close to the door.
             * This prevents the doors in all of the buildings from opening or closing when C is pressed
             */
            timer -= Time.deltaTime;
            if (timer <= 0 && Input.GetKeyDown(KeyCode.C))
            {
                if (!locked.isLocked)
                {
                    Collider2D[] players = Physics2D.OverlapCircleAll(trans.position, range, playerLayers);
                    if (players != null && players.Length > 0 && (players[0].transform.position - trans.position).magnitude < range) //checks player's distance from door
                    {
                        timer = 1f;//makes sure that the door does not open and close continuously while C key is pressed down
                        open = !open; //changes door from open to close, or vice versa
                        if (open)
                        {
                            //door opens, so door object swings open and lights turn on
                            trans.RotateAround(DoorHinge.transform.position, Vector3.forward, -90);
                            light.turnLightOn();
                        }
                        else
                        {
                            //door closes, door object swings closed
                            trans.RotateAround(DoorHinge.transform.position, Vector3.forward, 90);
                        }
                    }

                }
            }
        }
    }
}

