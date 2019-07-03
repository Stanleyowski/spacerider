using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

    private Transform target;


    private bool followRocket;


    public float min_Y_Treshold = -2.6f; //jak daleko mozna wyleicec zanim kamera podazy
	
	void Awake () {
        target = GameObject.FindGameObjectWithTag("Player").transform;
		
	}
	
	
	void Update () {
        Follow();
        
		
	}
    void Follow ()
    {
        // jeśli będzie mniejsza niż pozycja kamera nie podąża
        if(target.position.y < (transform.position.y - min_Y_Treshold))
        {
            followRocket = false;
        }
        // jeśli pozycja jest większa kamera podąża
        if(target.position.y > transform.position.y)
        {
            followRocket = true;
        }
        if (followRocket)
        {
            Vector3 temp = transform.position;
            temp.y = target.position.y;
            transform.position = temp;
        }

        }
}
