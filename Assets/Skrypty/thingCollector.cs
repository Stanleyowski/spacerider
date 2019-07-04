using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thingCollector : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "BG" || target.tag =="Spawner" || target.tag=="StarBoost" || target.tag=="FuelExtraBoost" || target.tag =="Meteor")
        {
            target.gameObject.SetActive(false);
        }
    }
}