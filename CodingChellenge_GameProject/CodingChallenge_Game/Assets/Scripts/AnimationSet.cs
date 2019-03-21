using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSet : MonoBehaviour
{

    public Animator animator;
    public string boolTrigger;
    private bool isInteractable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool(boolTrigger, isInteractable);   //Setting the bool of name (string) boolTrigger of our animator (which we aquired at line 8)
    }                                                    //to the 'isInteractable' bool's value - every frame


    //Checking if GameObject of Tag player has collided with the trigger collider on the object this script is attached to
    //If Player has entered the interactable field that isInteractable is true which will set off our animation accordingly
    //Interactable field/space - a field that we have to be in, in order to interact with a certain object
    //If our player exits the interactable field the isInteractable value is set to false
    //Triggering our animation accordigly
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInteractable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInteractable = false;
        }
    }
}
