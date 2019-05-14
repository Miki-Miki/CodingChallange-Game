using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkToNPC : MonoBehaviour
{
    private bool isInteractable;
    private ConditionChecker condition;
    private Scene activeScene;

    void Update()
    {
        activeScene = SceneManager.GetActiveScene();
        condition = GameObject.FindGameObjectWithTag("ConditionChecker").GetComponent<ConditionChecker>();
        
        if(Input.GetButtonDown("Use") && isInteractable && activeScene.buildIndex == 4)
        {
            condition.setNPC1Open(true);
        }

        if(Input.GetButtonDown("Use") && isInteractable && activeScene.buildIndex == 5)
        {
            condition.setNPC1OpenPRL(true);
        }


    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
            isInteractable = true;
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
            isInteractable = false;
    }
}
