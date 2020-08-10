using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    public double maxHunger = 100;
    public double currentHunger;
    public double StarvationSpeed = 0.01;
    // Start is called before the first frame update
    void Start()
    {
        //current hunger is set to max hunger, showing the character is full
        currentHunger = maxHunger;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //hunger is decreased each update, getting closer to starvation
        currentHunger -= StarvationSpeed * Time.fixedDeltaTime;
    }

    public void Eat(int foodVal)
    {
        //the character eats, increasing current hunger value, showing the character is less hungry
        currentHunger += foodVal;
    }
}
