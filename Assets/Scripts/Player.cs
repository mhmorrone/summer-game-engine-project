using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Player will contain all stats/attributes of the player character. Add to this as we develop more scripts for the player character.
public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Health playerHealth;
    public Hunger playerHunger;
    public Text textbox;
    public Text textbox2;
    // Start is called before the first frame update
    void Start()
    {
        textbox = GameObject.FindGameObjectWithTag("Hunger").GetComponent<Text>();
        textbox2 = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textbox.text = "Hunger: " + playerHunger.currentHunger;
        textbox2.text = "Health: " + playerHealth.currentHealth;

        if (playerHunger.currentHunger == 0)
        {
            playerHealth.currentHealth -= 0.1f * Time.fixedDeltaTime;
        }

        if (playerHunger.currentHunger >= 0)
        {
            playerHunger.currentHunger -= playerHunger.StarvationSpeed * Time.fixedDeltaTime;
        }
        
        //Debug.Log("Hunger is " + playerHunger.currentHunger);
       // Debug.Log("Health is " + playerHealth.currentHealth);

        if (playerHealth.currentHealth == 0)
        {
            Debug.Log("You died!");
        }
    }
}
