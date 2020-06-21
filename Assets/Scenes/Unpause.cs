using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Unpause : MonoBehaviour
{
    public Button unPause;
    // Start is called before the first frame update
    void Start()
    {
        unPause = GameObject.FindGameObjectWithTag("unpause").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            print("p key is held down");
            unPause.onClick.Invoke();
        }
    }
    
}
