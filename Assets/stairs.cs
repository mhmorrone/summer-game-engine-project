using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stairs : MonoBehaviour
{
    public GameObject StairsLanding;

    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.transform.Translate(StairsLanding.transform.position - col.gameObject.transform.position);
    }
}
