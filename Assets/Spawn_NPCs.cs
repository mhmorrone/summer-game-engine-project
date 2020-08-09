using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_NPCs : MonoBehaviour
{
    
    public GameObject NPC1;
    public GameObject NPC2;
    public Transform topBound;
    public Transform bottomBound;
    public Transform rightBound;
    public Transform leftBound;
    float Horizontal;
    float Vertical;

    // Start is called before the first frame update
    void Start()
    {
        int num_people =  2 * UnityEngine.Random.Range(100, 500);
        Horizontal = UnityEngine.Random.Range(leftBound.position.x, rightBound.position.x);
        Vertical = UnityEngine.Random.Range(bottomBound.position.y, topBound.position.y);
        for (int i = 0; i < num_people; i += 2)
        {
            Horizontal = UnityEngine.Random.Range(leftBound.position.x, rightBound.position.x);
            Vertical = UnityEngine.Random.Range(bottomBound.position.y, topBound.position.y);
            Instantiate(NPC1, new Vector2(Horizontal, Vertical), topBound.rotation);
            Horizontal = UnityEngine.Random.Range(leftBound.position.x, rightBound.position.x);
            Vertical = UnityEngine.Random.Range(bottomBound.position.y, topBound.position.y);
            Instantiate(NPC2, new Vector2(Horizontal, Vertical), topBound.rotation);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
