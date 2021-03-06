﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Transform trans;
    Actions action;
    int cnt;
    // Start is called before the first frame update
    void Start()
    {
        action = trans.GetComponent<Actions>();
        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (action.isDead)
        {
            return;
        }
        cnt -= 1;
        /* 
         * If within attacking range to a character, zombie attacks that character using fight and they eat
         * Otherwise, they follow the closest character who is alive
         */
        if (action.distance <= action.attackRange)
        {
            action.follow = false;
            action.animator.SetFloat("IsWalking", 0);
            if (cnt <= 0)
            {
                action.Fight(true);
                trans.GetComponent<Hunger>().Eat(5);
                cnt = 25;
            }
        }
        else
            action.follow = true;
    }
}
