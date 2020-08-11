using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Mime;
using UnityEngine;

public class Spawn_Zombies : MonoBehaviour
{
    //difficulty is a number between 1 and 5 that increases the number of zombies the game starts out with
    public int difficulty = 3;
    public GameObject zombie1;
    public GameObject zombie2;
    public GameObject player;
    //Game map boundaries
    public Transform topBound;
    public Transform bottomBound;
    public Transform rightBound;
    public Transform leftBound;
    float Horizontal;
    float Vertical;

    // Start is called before the first frame update
    void Start()
    {
        //a random amount of zombies are spawned into the game at the start to fill the map
        //it is the same amount of the female and male zombies
        //the number of zombies is kept lower to prevent lagging
        int num_zombies = difficulty * 2 * UnityEngine.Random.Range(1, 10);//determines number of zombies to be spawned throughout the board
        for (int i = 0; i < num_zombies; i += 2)
        {
            //Determines random position within the map and spawns a zombie there
            Horizontal = UnityEngine.Random.Range(leftBound.position.x, rightBound.position.x);
            Vertical = UnityEngine.Random.Range(bottomBound.position.y, topBound.position.y);
            Instantiate(zombie1, new Vector2(Horizontal, Vertical), topBound.rotation);
            Horizontal = UnityEngine.Random.Range(leftBound.position.x, rightBound.position.x);
            Vertical = UnityEngine.Random.Range(bottomBound.position.y, topBound.position.y);
            Instantiate(zombie2, new Vector2(Horizontal, Vertical), topBound.rotation);
        }
        num_zombies = difficulty * 2 * UnityEngine.Random.Range(1, 10);//determines number of zombies to be spawned near the player
        //this is done so that the player immediately finds zombies and the map feels fuller
        for (int i = 0; i < num_zombies; i += 2)
        {
            //Determines random position within the map and spawns a zombie there
            Horizontal = UnityEngine.Random.Range(player.transform.position.x - 40, player.transform.position.x + 40);
            Vertical = UnityEngine.Random.Range(player.transform.position.y - 40, player.transform.position.y + 40);
            Instantiate(zombie1, new Vector2(Horizontal, Vertical), topBound.rotation);
            Horizontal = UnityEngine.Random.Range(player.transform.position.x - 40, player.transform.position.x + 40);
            Vertical = UnityEngine.Random.Range(player.transform.position.y - 40, player.transform.position.y + 40);
            Instantiate(zombie2, new Vector2(Horizontal, Vertical), topBound.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
