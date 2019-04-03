using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingDoor : MonoBehaviour
{
    private GameObject ConditionChecker;
    private ConditionChecker condition;
    private Animator animator;
    private LetterPopUp letter;
    private bool isInteractable;

    void Start()
    {
        ConditionChecker = GameObject.FindGameObjectWithTag("ConditionChecker");
        condition = ConditionChecker.GetComponent<ConditionChecker>();
        animator = GetComponent<Animator>();  
        letter = GetComponent<LetterPopUp>();      
    }

    void Update()
    {
        if(condition.GetScenesSwitched() < 2)
        {
            this.enabled = false;
            letter.enabled = false;
        }
        else
        {
            this.enabled = true;
            letter.enabled = true;
        }

        if(condition.GetScenesSwitched() > 2 && isInteractable == true
        && Input.GetButtonDown("Use"))
        {
            animator.SetBool("isForAnimation", true);
        }
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isInteractable = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInteractable = true;
        }
    }
}
