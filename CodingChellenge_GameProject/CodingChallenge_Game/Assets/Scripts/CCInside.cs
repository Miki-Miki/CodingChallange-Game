using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCInside : MonoBehaviour
{
    // Animators for objectives
    public Animator cameraWarning;

    // Checkers for objectives
    private bool isForCamWarning = false;

    // Check if door open
    private bool hasDoorOpened = false;

    void Update() 
    {
        if(isForCamWarning && cameraWarning != null)
            cameraWarning.SetBool("isObjectiveAvailible", true);
        if(!isForCamWarning && cameraWarning != null)
            cameraWarning.SetBool("isObjectiveComplete", true);
    }

    public void setIsForCamWarning(bool set) { isForCamWarning = set; }
    public bool getIsForCamWarning() { return isForCamWarning; }
    public void setHasDoorOpened(bool set) { hasDoorOpened = set; }
    public bool getHasDoorOpened() { return hasDoorOpened; }
}
