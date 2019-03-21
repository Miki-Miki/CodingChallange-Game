using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    private bool isInteractable;
    public GameObject mainObject;
    public GameObject light;

    // Start is called before the first frame update
    void Start()
    {
        
        light.GetComponent<Light>().enabled = false;
        isInteractable = false;

    }

    // Update is called once per frame
    void Update()
    {
        //If we are in the interactable field (collider) and E is pressed
        if (isInteractable == true && Input.GetButtonDown("Use"))
        {
            Debug.Log("E is pressed");
            if (light.GetComponent<Light>().enabled == false)   //If the light is off, turn it on
            {
                light.GetComponent<Light>().enabled = true;
            }
            else if (light.GetComponent<Light>().enabled == true)   //If the light is on, turn it off
            {
                light.GetComponent<Light>().enabled = false ;
            }

        }
    }


    //Checking if player has enter or exited the interactable field of the object this script is attached to
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision with Player");
            isInteractable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player exited the collider");
            isInteractable = false;
        }
    }


}
