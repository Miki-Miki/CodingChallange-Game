using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showBuilding : MonoBehaviour
{
    public GameObject buildingCanvas;
    private bool animationRan = false;
    void OnTriggerEnter2D(Collider2D coll) 
    {
        if(coll.gameObject.tag == "Player" && !animationRan)
        {
            buildingCanvas.SetActive(true);
            animationRan = true;
        }
    }
}
