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
    private PlayerMovement mainPlayer;

    public GameObject info_letter_F;
    private float seconds_delay = 2.0f;
    //private float delay_player_for_seconds = 3.3f;

    void Start()
    {
        mainPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
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
 
    public void delay_player(float delayPlayerForSeconds)
    {
        StartCoroutine(Delay_player_movement(delayPlayerForSeconds));
    }

    void spawn_instruction_letter_F()
    {
        StartCoroutine(Delay_letter_F(seconds_delay));
    }
    
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
}
