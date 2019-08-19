﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D rocket;
    public float rocketSpeed = 2f;
    public float starBoost= 10f;
    public float extraFuelBoost = 15f;
    private bool initialBoost;
    private int boostCount;
    private bool lose;
    private GameObject fire;
    private scoreManager scoreManager;








    void Awake () {
        rocket = GetComponent<Rigidbody2D>();
        fire = gameObject.transform.GetChild(0).gameObject;
        scoreManager = FindObjectOfType<scoreManager>();
       

    }
	
	
	void FixedUpdate () {

        Flight();
	}
    void Flight()
    {

        if (lose)
            return;

        if (Input.GetAxisRaw("Horizontal") > 0) // jeśli naciśniemy prawy/d zwróci 1
        {
            rocket.velocity = new Vector2(rocketSpeed, rocket.velocity.y);
        }
        else
        {
            if (Input.GetAxisRaw("Horizontal") < 0)// jeśli naciśniemy lewy/a zwróci -1
            {
                rocket.velocity = new Vector2(-rocketSpeed, rocket.velocity.y);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {

        if (lose)
            return;
        if(target.tag == "ExtraFuelBoost")
        {
            if (!initialBoost) //jeśli nie ma boosta na start !
            {
                initialBoost = true;
                rocket.velocity = new Vector2(rocket.velocity.x, 18f);
                target.gameObject.SetActive(false);
                soundManager.instance.boostSoundEfects();

                //wyjście z triggera ze wzgledu na boost startowy

                return;
            }// start

           
        }
        if (target.tag == "StarBoost")
        {
            rocket.velocity = new Vector2(rocket.velocity.x, starBoost);
            target.gameObject.SetActive(false);
            boostCount++;
            
        }
        if (target.tag == "ExtraFuelBoost")
        {
            rocket.velocity = new Vector2(rocket.velocity.x, extraFuelBoost);
            target.gameObject.SetActive(false);
            boostCount++;
            soundManager.instance.boostSoundEfects();
        }
        if(boostCount ==2)
        {
            boostCount = 0;
            spawnerAttacherow.instance.spawner();
        }
        if(target.tag =="Upadek" || target.tag == "Meteor")
        {
            lose = true;
            gameManager.instance.Restart();
            soundManager.instance.gameOverSoundEfects();
            fire.SetActive(false);
            scoreManager.scoreIncreasing = false;


        }
      

    } // odpala się na trigger
}

