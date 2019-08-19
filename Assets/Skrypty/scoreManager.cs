using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class scoreManager : MonoBehaviour {
    public Text score;
    public Text highscore;

    public float scoreCounter;
    public float highscoreCounter;

    public float pointsPerSecond;




    public bool scoreIncreasing;

	// Use this for initialization
	void Start () {
        if(PlayerPrefs.GetFloat("HighScire")!=null)
        {
            highscoreCounter = PlayerPrefs.GetFloat("HighScore");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if(scoreIncreasing)
        {
            scoreCounter += pointsPerSecond * Time.deltaTime;
        }
        
        if(scoreCounter > highscoreCounter)
        {
            highscoreCounter = scoreCounter;
            PlayerPrefs.SetFloat("HighScore", highscoreCounter);
        }




        score.text = "Score: " + Mathf.Round(scoreCounter);
        highscore.text = "High Score: " + Mathf.Round(highscoreCounter);
	}
}
