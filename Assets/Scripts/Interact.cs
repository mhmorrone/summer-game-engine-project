using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public Rigidbody2D Player;
    public Rigidbody2D NPC;
    public bool dialogueStarted = false;
    public DialogueTrigger trigger;
    public DialogueManager dm;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(Player.transform.position, NPC.transform.position) < 10)
        {
            if ((Input.GetKeyDown("e") || Input.GetKeyDown("E")) && dialogueStarted == false)
            {
                trigger.TriggerDialogue();
                dialogueStarted = true;

            }
            else if ((Input.GetKeyDown("e") || Input.GetKeyDown("E")) && dialogueStarted == true)
            {
                dm.DisplayNextSentence();
            }

        }
        
    }
}
