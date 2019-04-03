using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionChecker : MonoBehaviour
{
    
    private bool portalOpenedForFirstTime;
    private bool computerScreenOpened;
    private static int ScenesSwitched = 0;
    
    public void SetBoolPortalOpenedForFristTime(bool checker) { portalOpenedForFirstTime = checker; }
    public bool GetBoolPortalOpenedForFristTime() { return portalOpenedForFirstTime; }

    public void SetComputerScreenOpened(bool checker) { computerScreenOpened = checker; }
    public bool GetComputerScreenOpened() { return computerScreenOpened; }

    public void SceneSwitched() { ScenesSwitched++; }
    public int GetScenesSwitched() {return ScenesSwitched; }

}
