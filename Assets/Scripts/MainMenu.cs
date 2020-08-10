using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
	public AudioMixer audioMixer;
    public Button play;
    public Button options;
    public Button quit;
    public Slider volumeSlider;
    public Button back;
	
	
    void Start()
    {
        play.onClick.AddListener(MenuClick);
        options.onClick.AddListener(MenuClick);
        quit.onClick.AddListener(MenuClick);
        back.onClick.AddListener(MenuClick);
        volumeSlider.onValueChanged.AddListener(SliderChange);
		audioMixer.SetFloat("volume", Mathf.Log10(1) * 20);
    }

    void MenuClick()
    {
        SoundManagerScript.PlaySound("menuSound");
    }
    void SliderChange(float val)
    {
        SoundManagerScript.PlaySound("sliderSound");
    }
    public void PlayGame ()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame ()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
