using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class OptionsScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        audioMixer.SetFloat("volume", Mathf.Log10(1) * 20);
    }

    
    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10 (volume) * 20);
    }

}
