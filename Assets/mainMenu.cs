using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
    //odpowiada za włączenie kolejnej sceny czyli sceny z grą
	public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // odpowaida za wyłączenie gry
    public void TurnOffGame()
    {
        Application.Quit();
        {
            Debug.Log("Wyłączono");
        }
    }
    // Dla opcji nie trzeba programować dodatkowego kodu - jest to umożliwione bezpośrednio z Unity
}
