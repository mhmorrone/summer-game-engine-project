using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MainGameScript : MonoBehaviour
{
    public Button pauseButton;
    public Button openInventory;
    public Button closeInventory;
    public bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseButton = GameObject.FindGameObjectWithTag("Pause").GetComponent<Button>();
        openInventory = GameObject.FindGameObjectWithTag("Open").GetComponent<Button>();
        closeInventory = GameObject.FindGameObjectWithTag("Close").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            print("p key is held down");
            pauseButton.onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (open == false)
            {
                open = true;
                openInventory.onClick.Invoke();
            }
            else
            {
                open = false;
                closeInventory.onClick.Invoke();
            }
        }
        
    }
}
