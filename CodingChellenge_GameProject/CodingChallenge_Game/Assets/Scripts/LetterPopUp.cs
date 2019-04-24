using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPopUp : MonoBehaviour
{
    public Animator animator;            //Grabbing the animator of the object we want to animate
    public string boolTrigger;
    private bool isTrigger = false;      //Interactable field is initialized to false
    public float delay;                  //this variable allows us to set a certain delay on the triggering of our animation
    private GameObject[] instructionLetters;

    void Start() 
    {
        instructionLetters = GameObject.FindGameObjectsWithTag("InstructionLetter");
    }

    void Update()
    {
        // animator = GameObject.FindGameObjectWithTag("Letter").GetComponent<Animator>();
        runCoroutine();                 //This function runs every frame (but the animation will only be delayed if we enter the interactable field (line 26)                
    }

    //This coroutine delays the triggering of an animation
    IEnumerator Delay(float seconds_delay)
    {
        yield return new WaitForSeconds(seconds_delay);     //Delay the code that comes after this line for seconds_delay
        if(animator != null) {
            animator.SetBool(boolTrigger, isTrigger);
        }
        else {
            for(int i = 0; i < instructionLetters.Length; i++) {
                if(instructionLetters[i] != null)
                    instructionLetters[i].GetComponent<Animator>().SetBool("isInteractable", isTrigger);
            }
        }

    }

    void runCoroutine()
    {
        if (isTrigger == true)                      //If the object enters the interactable field
        {
            StartCoroutine(Delay(delay));           //Start the delay courutine
        }
    }

    //For comments on the code bellow check "DescriptionPopUp.cs"
    void OnTriggerEnter2D(Collider2D collision)     
    {
        if(collision.tag == "Player")
        {
            isTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isTrigger = false;
        }
    }
}
