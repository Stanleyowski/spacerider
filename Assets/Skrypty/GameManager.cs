using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //public static System.Action OnGameStartedEvent = () => { };

    public static System.Action OnGameEndedEvent;
    
    public static GameManager instance;

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
        //OnGameStartedEvent();
    }
}