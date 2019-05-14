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
    public Animator CheckCompPRL;
    public Animator goOutside;
    private Animator cameraWarning;
    
    //Checkers for objectives
    private int objectiveTestPortal = 0;
    private int objectiveTestPortalComplete = 0;
    private bool cmpOpenInParallel = false;
    private bool isOutside = false;
    private bool isForCamWarning = false;
    private bool firstTimeInParllel = false;
    private bool firstTimeInOutdoors = false;

    //Checkers for terminals
    private int ntTerminalWasUsed = 0;
    private bool terminalIsOpen = false;
    private bool isDoorOneOpen = false;
    private bool PRL_DoorOpened = false;
    private bool isDoorTwoOpen = false;
    private bool PRL_DoorTwoOpened = false;
    private bool isCamOneKilled = false;
    private bool isCamTwoKilled = false;
    private bool isDoorThreeOpen = false;

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
        if (computerScreenOpened)
        {
            spawn_instruction_letter_F();
        }

        if (portalOpenedForFirstTime)
        {
            cameraAnimator.SetTrigger("firstPortal");
            playerAnimator.SetTrigger("firstPortal");
            portalOpenedForFirstTime = false;

        }

        // MANAGING OBJECTIVES
        if (computerScreenOpened && objectiveTestPortal == 1 && TestPortalAnim != null)
            delay_objective(3.0f, TestPortalAnim, "isObjectiveAvailible", true);
        else if (TestPortalAnim != null) 
            TestPortalAnim.SetBool("isObjectiveAvailible", false);

        if (objectiveTestPortalComplete == 1 && TestPortalAnim != null) {
            TestPortalAnim.SetBool("isObjectiveComplete", true);
            TestPortalAnim.SetBool("isObjectiveAvailible", false);
        }
        else if (TestPortalAnim != null) TestPortalAnim.SetBool("isObjectiveComplete", false);

        if (cmpOpenInParallel == true) 
            CheckCompPRL.SetBool("isObjectiveComplete", true);
        if (numberOfTimesPortalWasUsed == 2)
            delay_objective(6.0f, CheckCompPRL, "isObjectiveAvailible", true);

        if (numberOfTimesPortalWasUsed == 4)
            delay_objective(5.5f, goOutside, "isObjectiveAvailible", true);
        if (isDoorOpen == true)
            goOutside.SetBool("isObjectiveComplete", true);

   
    }

    IEnumerator Delay_letter_F(float delay_for_seconds) {
        yield return new WaitForSeconds(delay_for_seconds);
        if (computerScreenOpened && info_letter_F != null)
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

    public void cmpOpenedInParallel() { cmpOpenInParallel = true; }
    public bool getCmpOpenInParallel() { return cmpOpenInParallel; }
    public void stopOpenCompInParallelObjective() {
        OpenCompAnim.SetBool("isObjectiveComplete", true);
        OpenCompAnim.SetBool("isObjectiveAvailible", false);
    }

    public void SetIsOutside() { isOutside = true; }
    public bool GetIsOutside() { return isOutside; }

    //Terminals
    public void TerminalWasUsed() { ntTerminalWasUsed++; }
    public int GetNTTerminalWasUsed() { return ntTerminalWasUsed; }
    public void setTerminalIsOpen(bool isOpen) { terminalIsOpen = isOpen; }
    public bool getTerminalIsOpen() { return terminalIsOpen; }
    public void setDoorOneOpen(bool open) { isDoorOneOpen = open; }
    public bool getDoorOneOpen() { return isDoorOneOpen; }
    public bool getPRL_DoorOpen() { return PRL_DoorOpened; }
    public void setPRL_DoorOpen(bool set) { PRL_DoorOpened = set; }
    public void setDoorTwoOpen(bool open) { isDoorTwoOpen = open; }
    public bool getDoorTwoOpen() { return isDoorTwoOpen; }
    public bool getPRL_DoorTwoOpen() { return PRL_DoorTwoOpened; }
    public void setPRL_DoorTwoOpen(bool set) { PRL_DoorTwoOpened = set; }
    
    public void setIsForCamWarning(bool set) { isForCamWarning = set; }
    public bool getIsForCamWarning() { return isForCamWarning; }

    public void setCamOneKilled(bool set) { isCamOneKilled = set; }
    public bool getCamOneKilled() { return isCamOneKilled; }

    public void setCamTwoKilled(bool set) { isCamTwoKilled = set; }
    public bool getCamTwoKilled() { return isCamTwoKilled; }

    public void setDoorThreeOpen(bool set) { isDoorThreeOpen = set; }
    public bool getDoorThreeOpen() {return isDoorThreeOpen; }

    public void setFirstTimeInParallel(bool set) { firstTimeInParllel = set; }
    public bool getFirstTimeInPrallel() { return firstTimeInParllel; }

    public void setFirsTimeInOutdoors(bool set) { firstTimeInOutdoors = set; }
    public bool getFirstTimeInOutdoors() { return firstTimeInOutdoors; }
}
