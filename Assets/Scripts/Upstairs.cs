using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upstairs : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.transform.Translate(0f, 0f, 10f);
    }
}
