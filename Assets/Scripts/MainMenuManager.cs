﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void CloseApplication()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}