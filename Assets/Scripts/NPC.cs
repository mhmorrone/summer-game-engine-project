using System.Collections;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Cryptography;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Health NPCHealth;
    public Hunger NPCHunger;
    public Traits traits;
    public Skills skills;
    public GameObject zombie;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //health decreases when starving and hunger decreases each update when not starving
        if (NPCHunger.currentHunger == 0)
        {
            NPCHealth.currentHealth -= 0.1 * Time.fixedDeltaTime;
        }

        if (NPCHunger.currentHunger >= 0)
        {
            NPCHunger.currentHunger -= NPCHunger.StarvationSpeed * Time.fixedDeltaTime;
        }

        //if Health reaches 0, NPC dies
        if (NPCHealth.currentHealth <= 0)
        {
            Die();
        }
    }

    //Kill character - various scripts are unenabled to prevent movement, collisions, damage, etc
    public void Die()
    {
        GetComponent<Animator>().SetBool("IsDead", true);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        GetComponent<Actions>().isDead = true;
        GetComponent<NPCWalking>().isDead = true;
        GetComponent<Health>().isDead = true;
        if (GetComponent<Health>().zombieChance > UnityEngine.Random.Range(5, 75))
        {
            //turns into a zombie depending on number of zombie attacks and chance
            GetComponent<Animator>().SetBool("Zombie", true);
        }

    }

    
}
