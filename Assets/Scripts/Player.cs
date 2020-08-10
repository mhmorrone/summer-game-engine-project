using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;

//Player will contain all stats/attributes of the player character. Add to this as we develop more scripts for the player character.
public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Health playerHealth;
    public Hunger playerHunger;
    public HealthBar healthBar;
    //public Text textbox;
    //public Text textbox2;
    public Image weapon;
    public Image gear;
    public Image hold;
    public Image backpack;
    public Inventory inv;
    public Button weaponX;
    public Button gearX;
    public Button holdX;
    public Button backpackX;
    public LayerMask NPCLayers;
    public Transform trans;
    public float attackRange = 0.5f;
    public Animator animator;
    public int damage;
    public GameObject zombie;
    //public SoundManagerScript soundManager;

    // Start is called before the first frame update
    void Start()
    {
        inv = GetComponent<Inventory>();
        //textbox = GameObject.FindGameObjectWithTag("Hunger").GetComponent<Text>();
        //textbox2 = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
        weapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Image>();
        gear = GameObject.FindGameObjectWithTag("Gear").GetComponent<Image>();
        hold = GameObject.FindGameObjectWithTag("Hold").GetComponent<Image>();
        backpack = GameObject.FindGameObjectWithTag("Backpack").GetComponent<Image>();

        weaponX = GameObject.FindGameObjectWithTag("WeaponX").GetComponent<Button>();
        gearX = GameObject.FindGameObjectWithTag("GearX").GetComponent<Button>();
        holdX = GameObject.FindGameObjectWithTag("HoldX").GetComponent<Button>();
        backpackX = GameObject.FindGameObjectWithTag("BackpackX").GetComponent<Button>();

        healthBar.setMaxHealth(playerHealth.maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.isDead)
        {
            return;
        }
        if (inv.weapon != null)
        {
            weapon.sprite = inv.weapon.icon;
            weaponX.interactable = true;
        }
        else
        {
            weaponX.interactable = false;
            weapon.sprite = Resources.Load<Sprite>("Sprites/Inventory/swordplaceholder");
        }


        if (inv.gear != null)
        {
            gear.sprite = inv.gear.icon;
            gearX.interactable = true;
        }

        else
        {
            gearX.interactable = false;
            gear.sprite = Resources.Load<Sprite>("Sprites/Inventory/empty_gear");
        }


        if (inv.held != null)
        {
            hold.sprite = inv.held.icon;
            holdX.interactable = true;
        }

        else
        {
            holdX.interactable = false;
            hold.sprite = Resources.Load<Sprite>("Sprites/Inventory/hold");
        }


        if (inv.bag != null)
        {
            backpack.sprite = inv.bag.icon;
            backpackX.interactable = true;
        }
        else
        {
            backpack.sprite = Resources.Load<Sprite>("Sprites/Inventory/InventoryButton");
            backpackX.interactable = false;
        }

       // Debug.Log("Changing weapon sprite to: " + inv.weapon.title);
        //textbox.text = "Hunger: " + playerHunger.currentHunger;
        //textbox2.text = "Health: " + playerHealth.currentHealth;

        if (playerHunger.currentHunger == 0)
        {
            playerHealth.currentHealth -= 0.1 * Time.fixedDeltaTime;
        }

        if (playerHunger.currentHunger >= 0)
        {
            playerHunger.currentHunger -= playerHunger.StarvationSpeed * Time.fixedDeltaTime;
        }

        //Debug.Log("Hunger is " + playerHunger.currentHunger);
        // Debug.Log("Health is " + playerHealth.currentHealth);

        // Health Bar Update
        healthBar.setHealth(playerHealth.currentHealth);


        if (playerHealth.currentHealth <= 0)
        {
            Die();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UnityEngine.Debug.Log("Attack!");
            Attack();
        }
    }

    void Attack()
    {
        SoundManagerScript.PlaySound("hit");
        animator.SetTrigger("Attack");
        Collider2D[] hitCharacters = Physics2D.OverlapCircleAll(trans.position, attackRange, NPCLayers);
        foreach (Collider2D character in hitCharacters)
        {
            character.GetComponent<Health>().TakeDamage(damage);
        }
    }

    public void Die()
    {
        SoundManagerScript.PlaySound("death");
        trans.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        animator.SetBool("IsDead", true);
        playerHealth.isDead = true;
        playerMovement.enable = false;
        if (GetComponent<Health>().zombieChance > UnityEngine.Random.Range(5, 100))
        {
            animator.SetBool("Zombie", true);
        }
    }

    /*public void Zombieify()
    {
        Instantiate(zombie, playerHunger.GetComponent<Transform>().position, playerHunger.GetComponent<Transform>().rotation);
        Destroy(gameObject);
    }*/
}
