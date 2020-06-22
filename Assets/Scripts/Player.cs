using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player will contain all stats/attributes of the player character. Add to this as we develop more scripts for the player character.
public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Health playerHealth;
    public Hunger playerHunger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHunger.currentHunger() == 0)
        {
            playerHealth.currentHealth() -= 0.1f;
        }
    }
}
