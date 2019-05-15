using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkToNPC2 : MonoBehaviour
{
    public Animator objectiveAnimator;
    public GameObject colliderWall;
    public Animator objectiveAnimatorPRL;

    private bool isInteractable;
    private ConditionChecker condition;
    private bool objComplete;
    private Scene activeScene;


    void Update()
    {
        activeScene = SceneManager.GetActiveScene();
        condition = GameObject.FindGameObjectWithTag("ConditionChecker").GetComponent<ConditionChecker>();
        
        if(activeScene.buildIndex == 4) 
        {
            if(Input.GetButtonDown("Use") && isInteractable)
            {
                condition.setNPC2Open(true);
            }
        
            if(!objComplete) objectiveAnimator.SetBool("isObjectiveAvailible", false);

            if(condition.getNPC1Open() && condition.getNPC1OpenPRL() && condition.getNPC2Open()
            && condition.getNPC2OpenPRL())
            {
                objectiveAnimator.SetBool("isObjectiveAvailible", true);
                colliderWall.SetActive(false);
            }
        }

        if(activeScene.buildIndex == 5)
        {
            if(Input.GetButtonDown("Use") && isInteractable)
            {
                condition.setNPC2OpenPRL(true);
            }
        
            if(!objComplete) objectiveAnimatorPRL.SetBool("isObjectiveAvailible", false);

            if(condition.getNPC1OpenPRL() && condition.getNPC2OpenPRL()) 
            {
                objectiveAnimatorPRL.SetBool("isObjectiveAvailible", true);
            }
        }
    }

    IEnumerator completeObjective(float delay)
    {
        yield return new WaitForSeconds(delay);
        objectiveAnimator.SetBool("isObjectiveComplete", true);
        objComplete = true;

    }

    public void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
            isInteractable = true;

        Debug.Log("NPC1: " + condition.getNPC1Open() + "\nNPC2: " + condition.getNPC2Open());
    }

    public void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
            isInteractable = false;
    }
}
