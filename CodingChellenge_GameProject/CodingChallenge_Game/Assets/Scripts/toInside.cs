using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toInside : MonoBehaviour
{
    public GameObject SceneTransitionCanvas;
    void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "Player")
            SceneTransitionCanvas.GetComponent<Animator>().SetBool("isEnteringScene", true);

    }
}
