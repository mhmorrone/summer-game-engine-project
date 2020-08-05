using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
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
        cnt -= 1;
        if (action.distance <= action.attackRange)
        {
            action.follow = false;
            action.animator.SetFloat("IsWalking", 0);
            if (cnt <= 0)
            {
                action.animator.SetTrigger("Attack");
                //action.Fight();
                cnt = 25;
            }
        }
        else
            action.follow = true;
        /*if ((player.transform.position - trans.position).magnitude < 3f)
        {
            //if (UnityEngine.Random.Range(0, 1) == 1)
            //{
                GetComponent<Actions>().Fight();
                UnityEngine.Debug.Log("Fight!");
            //}
        }*/
    }
}
