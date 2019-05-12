using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepDoorOpen : MonoBehaviour
{
    private ConditionChecker conditionChecker;

    void Update()
    {
        conditionChecker = GameObject.FindGameObjectWithTag("ConditionChecker").GetComponent<ConditionChecker>();
    }

    public void PRL_DoorOpened()
    {
        conditionChecker.setPRL_DoorOpen(true);
            
    }
   
    public void PRL_DoorTwoOpened()
    {
       conditionChecker.setPRL_DoorTwoOpen(true);
    }

}
