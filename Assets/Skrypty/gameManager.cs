using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static System.Action OnGameEndedEvent;
    public static gameManager instance;
   

    void Awake()
    {
        if (instance == null)
            instance = this;

    }

    public void Restart()
    {
        OnGameEndedEvent();
        Invoke("LoadGame", 2f);
    }
    void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}