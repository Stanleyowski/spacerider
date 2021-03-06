﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerAttacherow : MonoBehaviour {
    public static spawnerAttacherow instance;


    [SerializeField]
        private GameObject left_Spawner, right_Spawner;

    private float left_X_Min = -2.4f, left_X_Max = -1f, right_X_Min = 2.4f, right_X_Max = 1f;
    private float y_Threshold = 4.5f;
    private float last_Y;

    public int spawn_Count = 8;
    private int spawner_Spawned;

    [SerializeField]
    private Transform spawner_Parent;

    [SerializeField]
    private GameObject meteor;
    public float meteor_Y = 6;
    private float meteor_x_Min = -1.677f,  meteor_x_Max = 0.154f;

    void Awake () {
        if (instance == null)
            instance = this;
		
	}
    private void Start()
    {
        last_Y = transform.position.y;
        spawner();
    }
    //spawner spawn xD
    public void spawner()
    {
        Vector2 temp = Vector2.zero;
        GameObject newSpawn = null;

        for(int i = 0; i < spawn_Count; i++)
        {
            //dodatnie liczby spawnujemy prawy 
            temp.y = last_Y;
            if((spawner_Spawned % 2) == 0) //jeśli zero jest resztą
            {
                
                temp.x = Random.Range(left_X_Min, left_X_Max);

                newSpawn = Instantiate(right_Spawner, temp, Quaternion.identity);
            }
            else //nieparzyste liczby
            {
                temp.x = Random.Range(right_X_Min, right_X_Max);

                newSpawn = Instantiate(left_Spawner, temp, Quaternion.identity);
            }
            newSpawn.transform.parent = spawner_Parent;
            //roznica w odleglosci platoformy od rakiety spawn
            last_Y += y_Threshold; 
            spawner_Spawned++;

        }
        if (Random.Range(0, 2) > 0)
        {
            spawnMeteor();
        }
    }

    void spawnMeteor()
    {
        Vector2 temp = transform.position;
        temp.x = Random.Range(meteor_x_Min, meteor_x_Max);
        temp.y += meteor_Y;
        GameObject nowyMeteor = Instantiate(meteor, temp, Quaternion.identity);
        nowyMeteor.transform.parent = spawner_Parent;
    }

    void Update () {
		
	}
}
