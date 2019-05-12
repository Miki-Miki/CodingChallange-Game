using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCInside : MonoBehaviour
{
    // Animators for objectives
    public Animator cameraWarning;

    // Checkers for objectives
    private bool isForCamWarning = false;

    void Update() 
    {
        if(isForCamWarning)
            cameraWarning.SetBool("isObjectiveAvailible", true);
        if(!isForCamWarning)
            cameraWarning.SetBool("isObjectiveComplete", true);
    }

    public void setIsForCamWarning(bool set) { isForCamWarning = set; }
    public bool getIsForCamWarning() { return isForCamWarning; }
}
