using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour {

    public static soundManager instance;
    [SerializeField]
    private AudioClip boostClip, gameOverClip;
    [SerializeField]
    private AudioSource soundEfects;
    
	void Awake ()
    {
        if (instance == null)
            instance = this;
	}
    public void boostSoundEfects()
    {
        soundEfects.clip = boostClip;
        soundEfects.Play();
    }
    public void gameOverSoundEfects()
    {
        soundEfects.clip = gameOverClip;
        soundEfects.Play();
    }



}
