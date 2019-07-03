using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D rocket;
    public float rocketSpeed = 2f;
    public float fuelBoost= 10f;
    public float extraFuelBoost = 15f;
    private bool initialBoost;
    private int boostCount;
    private bool lose;


	
	void Awake () {
        rocket = GetComponent<Rigidbody2D>();
		
	}
	
	
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "ExtraFuelBoost")
        {
            if (!initialBoost) //jeśli nie ma boosta na start !
            {
                initialBoost = true;
                rocket.velocity = new Vector2(rocket.velocity.x, 18f);
                target.gameObject.SetActive(false);
                //dźwięk

                //wyjście z triggera ze wzgledu na boost startowy

                return;
            }
        }
    } // odpala się na trigger
}
