using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public Button quit;

    void Start()
    {

    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
