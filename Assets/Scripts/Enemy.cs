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
    // Start is called before the first frame update
    void Start()
    {
        action = trans.GetComponent<Actions>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (action.distance <= action.attackRange)
        {
            action.animator.SetTrigger("Attack");
        }
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
