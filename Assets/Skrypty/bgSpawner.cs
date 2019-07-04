using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgSpawner : MonoBehaviour {

    private GameObject[] tla;
    private float wysokosc;
    private float najwyzszawysokosc_Y_Pos;

   void Awake()
    {
        tla = GameObject.FindGameObjectsWithTag("BG");
    }

    void Start () {
        wysokosc = tla[0].GetComponent<BoxCollider2D>().bounds.size.y;

        najwyzszawysokosc_Y_Pos = tla[0].transform.position.y;
		for(int i =1; i < tla.Length; i++)
        {
            if (tla[i].transform.position.y > najwyzszawysokosc_Y_Pos)
                najwyzszawysokosc_Y_Pos = tla[i].transform.position.y;
        }
	}


    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "BG")
        {
            if(target.transform.position.y >=najwyzszawysokosc_Y_Pos )
            {
                Vector3 temp = target.transform.position;
                for(int i = 0; i <tla.Length; i++)
                {
                    //jeśli bg w indeksie i nie jest akywne w hierarchii
                    if (!tla[i].activeInHierarchy)
                    {
                        temp.y += wysokosc;
                        tla[i].transform.position = temp;
                        tla[i].gameObject.SetActive(true);
                        najwyzszawysokosc_Y_Pos = temp.y;
                    }
                }
            }
        }
    }
}
