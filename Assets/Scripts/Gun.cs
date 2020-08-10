using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firepoint;
    public float bulletForce = 10f;
    public GameObject bullet;
    public Camera cam;
    public float timeBtwnBullets = 0.2f;//How fast multiple shots can be fired. I.e. A machine gun will be much faster, and have a much lower value, than a hand gun or shot gun
    public int bulletsPerReload = 20;//How many bullets per clip, or how many shots can be taken before reloading
    public bool reload = false;

    Vector3 mousePos;
    float timer;
    float bulletsLeft;

    void Start()
    {
        bulletsLeft = bulletsPerReload;//start with a full clip
        timer = timeBtwnBullets; 
    }

    // Update is called once per frame
    void Update()
    {
        //On mouse click, the gun shoots
        //Only shoots when timer is greater than timeBtwnBullets, so that a pistol or something cannot shoot at the speed or amount of bullets as a machine gun
        timer += Time.deltaTime;
        if(timer > timeBtwnBullets)
        {
            if (Input.GetAxisRaw("Fire1") == 1)
            {
                Shoot();
                timer = 0;
            }
        }
        if(reload)
        {
            Reload();//reload the gun if reload is activated
        }
        
    }
    
    //Shoots bullet when called
    void Shoot()
    {
        //shoots toward mouse position
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        firepoint.LookAt(mousePos, Vector3.forward);
        if (bulletsLeft > 0)//when bullets in the clip run out, the gun cannot be shot and player must reload before shooting again
        {
            GameObject b = Instantiate(bullet, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);//force is added to the bullet prefab to shoot it across screen
            bulletsLeft -= 1;//amount of bullets left decreases each time one is shot
        }
        
    }

    //Reload Gun
    void Reload()
    {
        //bullet amount is increased to full amount since a new clip has been added
        bulletsLeft = bulletsPerReload;
        reload = false;
    }
}
