using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
   /* public int mentalHealth;
    public int physicalHealth;
    //public int[] health = { mentalHealth, physicalHealth };
    public int inventing;
    public int building;
    public int maintenance;
    //public int[] crafting = { inventing, building, maitenance };
    public int knowledge;
    public int treatment;
    //public int[] medicine = { knowledge, treatment };
    public int leadership;
    public int barter;
    //public int[] charisma = { leadership, barter };*/

    public enum Skill { Inventing, Building, Maitenance, Knowledge, Treatment, Leadership, Barter, MentalHealth, PhysicalHealth };
    int[] skillSet = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            skillSet[i] = UnityEngine.Random.Range(0, 100);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Customize character's skills
    void Customization(Skill skill, int amount)
    {
        skillSet[(int)skill] = amount;
    }

    //increase skill value
    void Learn(Skill skill, int amount )
    {
        skillSet[(int)skill] += amount;
    }
}
