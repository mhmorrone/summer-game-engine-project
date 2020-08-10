using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_NPCs : MonoBehaviour
{

    //The NPC character prefabs
    public GameObject NPC1;
    public GameObject NPC2;
    //boundaries of the game map
    public Transform topBound;
    public Transform bottomBound;
    public Transform rightBound;
    public Transform leftBound;
    float Horizontal;
    float Vertical;
    // Start is called before the first frame update
    void Start()
    {
        //a random amount of NPCs are spawned into the game at the start to fill the map
        //it is the same amount of the female and male NPCs
        int num_people = 2 * UnityEngine.Random.Range(100, 500); //determines number of NPCs to be spawned
        for (int i = 0; i < num_people; i += 2)
        {
            //Determines random position within the map and spawns an NPC there
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
