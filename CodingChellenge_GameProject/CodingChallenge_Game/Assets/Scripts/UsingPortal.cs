using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UsingPortal : MonoBehaviour
{
    public Animator descriptionAnimator;
    private bool isUsePressed;
    private bool isInteractable;
    public string descritpionBoolTrigger;
    //private GameObject playerToDisable;
    //private Transform player;
    //private GameObject PLAYER;
    [SerializeField] private string toScene;
    private Scene activeScene;  

    private GameObject ConditionChecker;
    private ConditionChecker condition;

    void Start()
    {
        ConditionChecker = GameObject.FindGameObjectWithTag("ConditionChecker");
        condition = ConditionChecker.GetComponent<ConditionChecker>();
    }  

    // Update is called once per frame
    void Update()
    {
        activeScene = SceneManager.GetActiveScene();
        // Debug.Log("Active-Scene Index: " + activeScene.name);

        if(activeScene.buildIndex == 2)
        {
            condition.SceneSwitched();
            InteractWithPortalToSceneByIndex(1);
        }
        
        if(activeScene.buildIndex == 1)
        {
            condition.SceneSwitched();
            InteractWithPortalToScene(toScene);
        }

        if(isInteractable && Input.GetButtonDown("Description"))
        {
            Debug.Log("Q pressed and is interactable");
            descriptionAnimator.SetBool(descritpionBoolTrigger, true);
        }
        
    }

    void InteractWithPortalToScene(string ToScene)
    {
        if(isInteractable && Input.GetButtonDown("Use"))
        {   
            isUsePressed = true;
            SceneManager.LoadScene(ToScene);
        }
        else
        {
            isUsePressed = false;
        }
    }

    void InteractWithPortalToSceneByIndex(int sceneIndex)
    {
        if(isInteractable && Input.GetButtonDown("Use"))
        {   
            isUsePressed = true;
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            isUsePressed = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInteractable = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInteractable = false;
        }
    }



}
