using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    // All audio clips should be implemented here. Follow the format.
    public static AudioClip menuSelect, menuSlide, hit, hurt, death;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        menuSelect = Resources.Load<AudioClip>("Sounds/menuSelect");
        menuSlide = Resources.Load<AudioClip>("Sounds/menuChange");
        hit = Resources.Load<AudioClip>("Sounds/hit");
        hurt = Resources.Load<AudioClip>("Sounds/hurt");
        death = Resources.Load<AudioClip>("Sounds/death");

        audioSrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "menuSound":
                audioSrc.PlayOneShot(menuSelect);
                break;
            case "sliderSound":
                audioSrc.PlayOneShot(menuSlide);
                break;
            case "hit":
                audioSrc.PlayOneShot(hit);
                break;
            case "hurt":
                audioSrc.PlayOneShot(hurt);
                break;
            case "death":
                audioSrc.PlayOneShot(death);
                break;

        }
    }
}
