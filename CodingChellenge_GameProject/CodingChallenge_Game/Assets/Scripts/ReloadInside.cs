using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadInside : MonoBehaviour
{
    private GameObject Player;
    private GameObject door1, door2, door3;
    private GameObject cam1, cam2;
    private ConditionChecker condition;
    private GameObject[] portal;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        condition = GameObject.FindGameObjectWithTag("ConditionChecker").GetComponent<ConditionChecker>();
        portal = GameObject.FindGameObjectsWithTag("Portal");
        door1 = GameObject.FindGameObjectWithTag("doorOne");
        door2 = GameObject.FindGameObjectWithTag("doorTwo");
        door3 = GameObject.FindGameObjectWithTag("doorThree");
        cam1 = GameObject.FindGameObjectWithTag("camOne");
        cam2 = GameObject.FindGameObjectWithTag("camTwo");
    }



    public void ReloadLevel()
    {
    
        cam1.GetComponent<Animator>().SetBool("killCamera", false);
        cam2.GetComponent<Animator>().SetBool("killCamera", false);

        Player.transform.position = new Vector3(105.65f, -1.94f, -4.340001f);
        Player.GetComponent<PlayerMovement>().enabled = true;
        door1.transform.position = new Vector3(114f, -2.58f, -4.9f);
        door2.transform.position = new Vector3(140.6f, -2.54f, -4.9f);
        door3.transform.position = new Vector3(196.98f, -2.48f, -6.490003f);
        condition.setDoorOneOpen(false);
        condition.setDoorTwoOpen(false);
        condition.setDoorThreeOpen(false);

        for(int i = 0; i < portal.Length; i++)
        {
            Destroy(portal[i]);
        }
        
    }
}
