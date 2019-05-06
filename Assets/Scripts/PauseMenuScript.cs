using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = true;
    }

    private void OnApplicationFocus(bool focus)
    {
        
    }

    private void OnApplicationPause(bool pause)
    {
        Time.timeScale = 0;
    }
}
