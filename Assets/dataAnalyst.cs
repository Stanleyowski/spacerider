using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataAnalyst : MonoBehaviour
{
    static dataAnalyst instance;
    [Multiline] public string log = "";

    int amountOfTests = 10;
    int currentTestNr = 0;
    float scoreSum = 0;


    void Awake() { 
        if (instance == null)
            Init();
        else
            Destroy(gameObject);
    }

    void Init() {
        Debug.Log("initialazing data analyst");
        Time.timeScale = 10;
        gameManager.OnGameEndedEvent = OnGameEndedEventHandler;
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnGameEndedEventHandler() {
        var scoreManager = FindObjectOfType<scoreManager>();
        scoreSum += scoreManager.scoreCounter;
        currentTestNr++;
        if (currentTestNr == amountOfTests)
            FinishTestingSeries();
    }

    void FinishTestingSeries() {
        Log("Średni czas: " + Math.Floor(scoreSum / amountOfTests ));
        currentTestNr = 0;
        scoreSum = 0;
    }
    void Log(string txt) {
        Debug.Log(txt + "\n");
        log += txt + "\n";
    }

}