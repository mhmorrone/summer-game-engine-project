using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
//using System.Media;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public bool follow = true;
    public Transform trans;
    public NPCWalking walkScript;
    public bool isDead = false;
    public LayerMask characterLayers;
    public float attackRange = 3f;
    public int damage = 5;
    public Vector3 attackOffset;
    public Animator animator;
    GameObject player;
    Rigidbody2D rb;
    public float distance;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            distance = Vector2.Distance(player.transform.position, trans.position);
            animator.SetFloat("Distance", distance);
            if (follow)
                Follow();
            if (Input.GetKeyDown(KeyCode.T))
            {
                walkScript.movement.x = 0;
                walkScript.movement.y = 0;
                walkScript.walk = 0;
                Talk();
            }
        }
        
    }

    //Follow player - activate when part of the group for the player
    public void Follow()
    {
        Vector2 target = new Vector2(player.transform.position.x + UnityEngine.Random.Range(-5f, 5f), player.transform.position.y + UnityEngine.Random.Range(-5f, 5f));
        Vector2 newPos = Vector2.MoveTowards(trans.position, target, walkScript.moveSpeed * Time.fixedDeltaTime);
        animator.SetFloat("Vertical", (newPos.y - trans.position.y) * 100);
        animator.SetFloat("Horizontal", (newPos.x - trans.position.x) * 100);
        animator.SetFloat("IsWalking", 1);
        trans.GetComponent<Rigidbody2D>().MovePosition(newPos);
    }

    //Fight
    public void Fight()
    {
        animator.SetFloat("IsWalking", 0);
        Vector3 pos = trans.position;
        pos += trans.right * walkScript.movement.x;
        pos += trans.up * walkScript.movement.y;

        Collider2D[] hitCharacters = Physics2D.OverlapCircleAll(trans.position, attackRange, characterLayers);
        foreach(Collider2D character in hitCharacters)
        {
            character.GetComponent<Health>().TakeDamage(damage);
        }
    }


    //Move NPC to certain place
    public void Move()
    {

    }

    //Talk to player
    public void Talk()
    {
        //walkScript.enable = false;
        //Display dialogue and have interactable elements
        //walkScript.enable = true;
        //Debug.Log("Hi");
    }

    //Can place other actions for NPCs here (such as trade, fighting, etc.)
    //Has potential to activate these functions through buttons available in dialogue or as a result of certain actions
}
