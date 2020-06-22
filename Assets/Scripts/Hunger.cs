using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    public double maxHunger = 100f;
    public double currentHunger;
    public Health health;
    public double StarvationSpeed = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        currentHunger = maxHunger;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentHunger -= StarvationSpeed * Time.fixedDeltaTime;
        if (currentHunger == 0)
        {
            health.currentHealth -= 0.1f * Time.fixedDeltaTime;
        }
    }

    public void Eat(int foodVal)
    {
        currentHunger += foodVal;
    }
}
