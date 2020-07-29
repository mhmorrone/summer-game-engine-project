using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform trans; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players != null)
        {
            if ((players[0].transform.position - trans.position).magnitude > 100f)
            {
                GetComponent<Actions>().Follow(0.1f);
            }
            if ((players[0].transform.position - trans.position).magnitude < 3f)
            {
                //if (UnityEngine.Random.Range(0, 1) == 1)
                //{
                    GetComponent<Actions>().Fight();
                UnityEngine.Debug.Log("Fight!");
                //}

            }
        }
    }
}
