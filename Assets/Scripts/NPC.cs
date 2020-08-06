﻿using System.Collections;
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
    //public GameObject npc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NPCHunger.currentHunger == 0)
        {
            NPCHealth.currentHealth -= 0.1f * Time.fixedDeltaTime;
        }

        if (NPCHunger.currentHunger >= 0)
        {
            NPCHunger.currentHunger -= NPCHunger.StarvationSpeed * Time.fixedDeltaTime;
        }

        //Debug.Log("Hunger is " + playerHunger.currentHunger);
        // Debug.Log("Health is " + playerHealth.currentHealth);

        if (NPCHealth.currentHealth <= 0)
        {
            Die();
        }
    }

    //Kill character
    public void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        GetComponent<Actions>().isDead = true;
        GetComponent<NPCWalking>().isDead = true;
        GetComponent<Health>().isDead = true;
        if (GetComponent<Health>().zombieChance > UnityEngine.Random.Range(5, 105))
        {
            for(int i = 200; i > GetComponent<Health>().zombieChance; i--)
            {
                //Wait an amount of time inversely proportional to the number of times character was attacked by a zombie to become a zombie
            }
            Zombieify();
        }

    }

    public void Zombieify()
    {
        Instantiate(zombie, NPCHunger.GetComponent<Transform>().position, NPCHunger.GetComponent<Transform>().rotation);
        Destroy(gameObject);
    }
}
