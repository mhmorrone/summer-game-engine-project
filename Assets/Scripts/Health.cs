using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Health : MonoBehaviour
{
    public double maxHealth = 100;
    public double currentHealth;
    public double recoverySpeed = 0.05;
    public double damageResistance = 1;
    public bool isDead = false;
    public int zombieChance;
    
    // Start is called before the first frame update
    void Start()
    {
        //set current health to the max health level and set chance of becoming a zombie to 0
        currentHealth = maxHealth;
        zombieChance = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            //if the character is not dead, the character slowly gains health over time if under the max health level up to the max health level
            if (currentHealth < maxHealth)
                currentHealth += recoverySpeed * Time.fixedDeltaTime;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
        
    }

    public void TakeDamage(int damage)
    {
        //character's health decreases by a certain amount and the hurt animation shows this
        currentHealth -= damage / damageResistance;
        GetComponent<Animator>().SetTrigger("Hurt");
    }

    public void Heal(int heal)
    {
        //character gains a certain amount of health
        currentHealth += heal;
    }
}
