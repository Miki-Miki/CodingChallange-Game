using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionChecker : MonoBehaviour
{
    
    private bool portalOpenedForFirstTime;
    public bool computerScreenOpened;
    private static int ScenesSwitched = 0;
    private int numberOfTimesPortalWasUsed = 1;
    private int numberOfTimesPortalWasSpawned = 0;
    
    public Animator cameraAnimator;
    public Animator playerAnimator;
    private Animator toOutdoorsAnim;
    private PlayerMovement mainPlayer;

    private bool isDoorOpen;
    private bool exitingRoom;

    
    // Animators for objectives 
    public Animator TestPortalAnim;
    public Animator OpenCompAnim;
    
    //Checkers for objectives
    private int objectiveTestPortal = 0;
    private int objectiveTestPortalComplete = 0;

    public GameObject info_letter_F;
    private float seconds_delay = 2.0f;
    //private float delay_player_for_seconds = 3.3f;

    void Start()
    {
        mainPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        delay_objective(2.0f, OpenCompAnim, "isObjectiveAvailible", true);
        if(GameObject.FindGameObjectWithTag("trToOutdoors") != null) {
            toOutdoorsAnim = GameObject.FindGameObjectWithTag("trToOutdoors").GetComponent<Animator>();
        }
    }

    void Update()
    {
        if(computerScreenOpened)
        {
            spawn_instruction_letter_F();
        }

        if(portalOpenedForFirstTime)
        {
            cameraAnimator.SetTrigger("firstPortal");
            playerAnimator.SetTrigger("firstPortal");
            portalOpenedForFirstTime = false;

        }

        if(computerScreenOpened && objectiveTestPortal == 1) delay_objective(2.0f, TestPortalAnim, "isObjectiveAvailible", true);
        else TestPortalAnim.SetBool("isObjectiveAvailible", false);

        if(objectiveTestPortalComplete == 1) {
            TestPortalAnim.SetBool("isObjectiveComplete", true);
            TestPortalAnim.SetBool("isObjectiveAvailile", false);
        }
        else TestPortalAnim.SetBool("isObjectiveComplete", false);
    }

    IEnumerator Delay_letter_F(float delay_for_seconds) {
        yield return new WaitForSeconds(delay_for_seconds);
        if(computerScreenOpened)
        {
            info_letter_F.gameObject.SetActive(true);
        }
    }

    IEnumerator Delay_player_movement(float delay_for_seconds)
    {
        mainPlayer.enabled = false;
        yield return new WaitForSeconds(delay_for_seconds);
        mainPlayer.enabled = true;
    }

    IEnumerator delay_objective_crtn(float delayInSeconds, Animator objectiveAnimator, string objectiveBool, bool isForAnim) {
        yield return new WaitForSeconds(delayInSeconds);
        objectiveAnimator.SetBool(objectiveBool, isForAnim);
    }

    public void delay_objective(float delayInSeconds, Animator objectiveAnimator, string objectiveBool, bool isForAnim) {
        StartCoroutine(delay_objective_crtn(delayInSeconds, objectiveAnimator, objectiveBool, isForAnim));
    }
 
    public void delay_player(float delayPlayerForSeconds)
    {
        StartCoroutine(Delay_player_movement(delayPlayerForSeconds));
    }

    void spawn_instruction_letter_F()
    {
        StartCoroutine(Delay_letter_F(seconds_delay));
    }

    

    //Set and get methods for conditions defining the game
    public void SetBoolPortalOpenedForFristTime(bool checker) { portalOpenedForFirstTime = checker; }
    public bool GetBoolPortalOpenedForFristTime() { return portalOpenedForFirstTime; }

    public void SetComputerScreenOpened(bool checker) { computerScreenOpened = checker; }
    public bool GetComputerScreenOpened() { return computerScreenOpened; }

    public void SceneSwitched() { ScenesSwitched++; }
    public int GetScenesSwitched() { return ScenesSwitched; }

    public void PortalWasUsed() { numberOfTimesPortalWasUsed++; }
    public int GetNumerOfTimesPortalWasUsed() { return numberOfTimesPortalWasUsed; }

    public void setPortalOpenedFirstTime() { portalOpenedForFirstTime = true; }

    public void portalWasInstantiated() { numberOfTimesPortalWasSpawned++; }
    public int getNumberOfTimesPortalWasSpawned() { return numberOfTimesPortalWasSpawned; }

    public void startTestPortalObjective() { objectiveTestPortal++; }
    public void stopTestPortalObjective() { objectiveTestPortalComplete++; }

    public void stopOpenCompObjective() {
        OpenCompAnim.SetBool("isObjectiveComplete", true);
        OpenCompAnim.SetBool("isObjectiveAvailible", false);
    }

    public void doorIsOpen() { isDoorOpen = true; }
    public void exitRoom() { exitingRoom = true; toOutdoorsAnim.SetTrigger("isTransitioning"); }
    public bool getExitingRoom() { return exitingRoom; }
}
