using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataAnalyst : MonoBehaviour {
    static DataAnalyst instance;
    [Multiline] public string log = "";

    int amountOfTests = 10;
    int currentTestNr = 0;
    float scoresSum = 0;

    void Awake() {
        if (instance == null) 
            Init();
        else 
            Destroy(gameObject);
    }

    void Init() {
        Debug.Log("initializing data analyst");
        Time.timeScale = 10;
        GameManager.OnGameEndedEvent = OnGameEndedEventHandler;
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void OnGameEndedEventHandler() {
        var scoreManager = FindObjectOfType<ScoreManager>();
        scoresSum += scoreManager.scoreCounter;
        currentTestNr++;
        if (currentTestNr == amountOfTests)
            FinshTestingSeries();
    }

    void FinshTestingSeries() {
        Log($"Średni czas: {(scoresSum / amountOfTests):0}");
        currentTestNr = 0;
        scoresSum = 0;
    }

    void Log(string txt) {
        Debug.Log(txt + "\n");
        log += txt + "\n";
    }
}