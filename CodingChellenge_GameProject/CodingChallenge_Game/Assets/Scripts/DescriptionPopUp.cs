using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionPopUp : MonoBehaviour
{
    public Animator animator;           //We must grab the animator of the object that will pop up
    public string boolTrigger;          //as well as the name of the bool that triggers the animation (which is set in the the objects animator)
    private bool isTrigger;     
    public GameObject computerLight;    //We must grab the light we will check if it is on or not (specifically for the desktop case)


    // Update is called once per frame
    void Update()
    {
        if (isTrigger && Input.GetButtonDown("Description")             //if we are in the interactable space and Q is pressed
            && computerLight.GetComponent<Light>().enabled == false)    //and the light is off
        {
            animator.SetBool(boolTrigger, isTrigger);                   //set the trigger bool to our bool that checks if we are in the interactable space
        }

        //Interactable field/space - a field that we have to be in, in order to interact with a certain object

        if (isTrigger == false || computerLight.GetComponent<Light>().enabled == true)  //If we are not in the interactable space
        {                                                                               //and the light is on
            animator.SetBool(boolTrigger, false);                                       //We set the animation to false
        }
    }

    //This function runs if its parameter has triggered (collided with) the object this script is on
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")      //If object of tag player enters the collider of object this script is attached to
        {
            isTrigger = true;               //Than we know that te player entered an (the) interactable field
        }
    }

    //This function runs when its parameter (collider) has exited the object's collider this script this script is attached to
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")      //If object of tag player exits the collider of object this script is attached to
        {
            isTrigger = false;              //Than we know the player has exited an (the) interactable field
        }
    }
}
