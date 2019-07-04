using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour {
    [SerializeField]
    private GameObject paliwo, gwiazda;


    [SerializeField]
    private Transform spawnPlace;
	
	void Start () {
        GameObject newObject = null;
        if(Random.Range(0, 10) > 3)  // mamy 60% na paliwo(45678910) i 40% na gwiazdę(0123) mocniejszyboost
        {
            newObject = Instantiate(paliwo, spawnPlace.position, Quaternion.identity);
        }
        else
        {
            newObject = Instantiate(gwiazda, spawnPlace.position, Quaternion.identity);
        }
        newObject.transform.parent = transform;
	}
	
	
}
