using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataAnalyst : MonoBehaviour {

    void Awake() {
        DontDestroyOnLoad(gameObject);
        
        Time.timeScale = 1;
        GameManager.OnGameEndedEvent = OnGameEndedEventHandler;
    }

    void OnGameEndedEventHandler() {
        var scoreManager = FindObjectOfType<ScoreManager>();
        Debug.Log($"{scoreManager.scoreCounter:0}");
    }
}