using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UsingDoor : MonoBehaviour
{
    private GameObject ConditionChecker;
    private ConditionChecker condition;
    private Animator animator;
    private Animator letterE;
    private bool isInteractable = false;
    private int usePressed = 0;

    void Start()
    {
        ConditionChecker = GameObject.FindGameObjectWithTag("ConditionChecker");
        condition = ConditionChecker.GetComponent<ConditionChecker>();
        animator = GetComponent<Animator>();  
        letterE = GameObject.Find("E").GetComponent<Animator>();     
    }

    void Update()
    {
        if(condition.GetScenesSwitched() < 2)
        {
            this.enabled = false;
        }
        else if (condition.GetScenesSwitched() >= 2)
        {
            this.enabled = true;
        }

        if((condition.GetScenesSwitched() >= 2) && isInteractable == true
        && Input.GetButtonDown("Use"))
        {
            if(usePressed > 0) condition.exitRoom();
            animator.SetBool("isForAnimation", true);
            condition.doorIsOpen();
            usePressed++;
        }
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isInteractable = true;
            if(condition.GetScenesSwitched() >= 2) 
                letterE.SetBool("isInteractable", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInteractable = false;
            if(condition.GetScenesSwitched() >= 2) 
                letterE.SetBool("isInteractable", false);
        }
    }
}
