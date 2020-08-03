using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip menuSelect, menuSlide;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        menuSelect = Resources.Load<AudioClip>("Sounds/menuSelect");
        menuSlide = Resources.Load<AudioClip>("Sounds/menuChange");

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

        }
    }
}
