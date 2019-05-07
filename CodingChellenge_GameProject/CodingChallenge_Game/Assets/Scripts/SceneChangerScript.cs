using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScript : MonoBehaviour
{
    private Animator animator;           
    public string enterTrigger;         //Name of bool that triggers the enter (Fade in) animation
    public string exitTrigger;          //Name of bool that triggers the exit (Fade out) animation
    private bool isEscapePressed;   
    private bool isUsePressed;
    private bool isInteractable;        //If we are in the interactable field (the collider on the object)
    public int sceneIndex;              
    private GameObject playerToDisable;  //Select the player object that will be disabled once the new 'scene' is launched
    public GameObject computerLight;    //Grabbing the light object to check if it is turned on or off
    private GameObject conditionChecker;
    private ConditionChecker condition;
    private Scene activeScene;

    void Start()
    {
        conditionChecker = GameObject.FindGameObjectWithTag("ConditionChecker");
        condition = conditionChecker.GetComponent<ConditionChecker>();
        playerToDisable = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        animator = GameObject.FindGameObjectWithTag("computerScreen").GetComponent<Animator>();
        activeScene = SceneManager.GetActiveScene();
        //If we are in the interactable field and Q button is pressed and the light is on
        if(isInteractable && Input.GetButtonDown("Description") && computerLight.GetComponent<Light>().enabled == true)
        {
            condition.SetComputerScreenOpened(true);
            isUsePressed = true;                                                //Remember that E was pressed
            animator.SetBool("isUsedPressed", true);                            //Trigger the animation because E is pressed
            playerToDisable.GetComponent<PlayerMovement>().enabled = false;     //Disable PlayerMovement script on player
            isEscapePressed = false;                                            //Remember that escape is not pressed
            animator.SetBool(exitTrigger, isEscapePressed);                     //Run the exit animation accordingly to ^ line
            condition.stopOpenCompObjective();

            Debug.Log("Opening computer screen.");

            if (activeScene.buildIndex == 3 && condition.getCmpOpenInParallel() == false) 
            {
                condition.cmpOpenedInParallel();
                condition.stopOpenCompInParallelObjective();
                condition.PortalWasUsed();
            }
        } 
        else
        {
            isUsePressed = false;                                               //Otherwise E was (is) not pressed
        }

        //If we are in the interactable field and ESC is pressed and the previes if-block did not run
        if(isInteractable && Input.GetButtonDown("Cancel"))             
        {
            isEscapePressed = true;                                         //Remember if escape was (is) pressed
            animator.SetBool(exitTrigger, isEscapePressed);                 //Trigger animation accordingly
            playerToDisable.GetComponent<PlayerMovement>().enabled = true;  //Enable our player
            isUsePressed = false;                                           //Remember if E was (is) pressed

            animator.SetBool(enterTrigger, isUsePressed);                   //Trigger animation accordingly
            condition.startTestPortalObjective();
        }
        else
        {
            isEscapePressed = false;                                        //Otherwise escape is or was not pressed
        }
        
    }

    //The code bellow regulates if we are in an interactable field
    //Interactable field - a field that we have to be in, in order to interact with a certain object
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
    
