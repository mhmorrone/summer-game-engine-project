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
        currentHunger = maxHunger;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentHunger -= StarvationSpeed * Time.fixedDeltaTime;
    }

    public void Eat(int foodVal)
    {
        currentHunger += foodVal;
    }
}
