using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform firepoint;
    public float bulletForce = 10f;
    public GameObject bullet;
    public Camera cam;
    public float timeBtwnBullets = 0.2f;
    public int bulletsPerReload = 20;
    public bool reload = false;

    Vector3 mousePos;
    float timer;
    float bulletsLeft;

    void Start()
    {
        bulletsLeft = bulletsPerReload;
        timer = timeBtwnBullets;
    }

    // Update is called once per frame
    void Update()
    {
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
            Reload();
        }
        
    }
    
    //Shoots bullet when called
    void Shoot()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        firepoint.LookAt(mousePos, Vector3.forward);
        if (bulletsLeft > 0)
        {
            GameObject b = Instantiate(bullet, firepoint.position, firepoint.rotation);
            Rigidbody2D rb = b.GetComponent<Rigidbody2D>();
            rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
            bulletsLeft -= 1;
        }
        
    }

    //Reload Gun
    void Reload()
    {
        bulletsLeft = bulletsPerReload;
        reload = false;
    }
}
