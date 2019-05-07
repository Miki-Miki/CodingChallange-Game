using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioning : MonoBehaviour
{

    private Scene activeScene;
    private Scene mainScene;
    public string toScene;
    public GameObject sceneTransitionCanvas;
    public GameObject ConditionCheckerObj;
    private ConditionChecker condition;
    private int timesPortalWasUsed;

    private int numberOfScenesSwitched;

    void Start()
    {
        mainScene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        //ConditionCheckerObj = GameObject.FindGameObjectWithTag("ConditionChecker");
        if(ConditionCheckerObj == null) 
        {
            ConditionCheckerObj = GameObject.FindGameObjectWithTag("ConditionChecker");
        }
        condition = ConditionCheckerObj.GetComponent<ConditionChecker>();

        timesPortalWasUsed = condition.GetNumerOfTimesPortalWasUsed();
        activeScene = SceneManager.GetActiveScene();
    }

    void Awake() 
    {
         if(timesPortalWasUsed >= 1)
        {
            sceneTransitionCanvas.GetComponent<Animator>().SetBool("hasEnteredScene", true);
            // StartCoroutine(Delay(delayForSeconds));
            // sceneTransitionCanvas.GetComponent<Animator>().SetBool("isEntereingScene", false);
        }
        Debug.Log("Times portal was used (Awake function): " + timesPortalWasUsed);
    }
    
    public void set_hasEnteredScene_to_true()
    {
        sceneTransitionCanvas.GetComponent<Animator>().SetBool("hasEnteredScene", true);
    }

     public void set_hasEnteredScene_to_false()
    {
        sceneTransitionCanvas.GetComponent<Animator>().SetBool("hasEnteredScene", false);
    }

    public void set_isEnteringScene_to_false()
    {
        sceneTransitionCanvas.GetComponent<Animator>().SetBool("isEnteringScene", false);
    }

    public void TransitionToScene()
    {
        if (activeScene.buildIndex == 3)
        {
            GoToSceneByIndex(2);
        }

        if (activeScene.buildIndex == 2)
        {
            GoToScene(toScene);
        }

        if (activeScene.buildIndex == 4)
            GoToSceneByIndex(5);
        
        if (activeScene.buildIndex == 5)
            GoToSceneByIndex(4);

        if (activeScene.buildIndex == 6)
            GoToSceneByIndex(7);
        
        if (activeScene.buildIndex == 7)
            GoToSceneByIndex(6);

    }

    public void set_animInt_to_one()
    {
        sceneTransitionCanvas.GetComponent<Animator>().SetInteger("timesPortalWasUsed", 1);
    }

    public void set_animInt_to_two()
    {
        sceneTransitionCanvas.GetComponent<Animator>().SetInteger("timesPortalWasUsed", 2);
    }

    void GoToSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    void GoToScene(string toScene)
    {
        SceneManager.LoadScene(toScene);
    }

}
