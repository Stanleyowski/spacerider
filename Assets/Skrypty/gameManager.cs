using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public static gameManager instance;




    void Awake()
    {
        if (instance == null)
            instance = this;

    }

    public void Restart()
    {
        Invoke("LoadGame", 2f);
    }
    void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}