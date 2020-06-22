using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Health : MonoBehaviour
{
    public double maxHealth = 100f;
    public double currentHealth;
    public double recoverySpeed = 0.05f;
    public double damageResistance = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth < maxHealth)
            currentHealth += recoverySpeed * Time.fixedDeltaTime;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage * damageResistance;

        if (currentHealth <= 0)
        {
            //Kill character
        }
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
    }
}
