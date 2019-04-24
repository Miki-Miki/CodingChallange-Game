using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionChecker : MonoBehaviour
{
    
    private bool portalOpenedForFirstTime;
    private bool computerScreenOpened;
    private static int ScenesSwitched = 0;
    private int numberOfTimesPortalWasUsed = 1;

    public GameObject info_letter_F;
    private float seconds_delay = 2.0f;

    void Update()
    {
        if(computerScreenOpened)
        {
            spawn_instruction_letter_F();
        }
    }

    IEnumerator Delay_letter_F(float delay_for_seconds) {
        yield return new WaitForSeconds(delay_for_seconds);
        if(computerScreenOpened)
        {
            info_letter_F.gameObject.SetActive(true);
        }
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
}
