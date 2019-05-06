using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UsingPortal : MonoBehaviour
{
    public Animator descriptionAnimator;
    private GameObject sceneTransitionCanvas;
    private bool isUsePressed = false;
    private bool isInteractable;
    public string descritpionBoolTrigger;

    //private GameObject playerToDisable;
    //private Transform player;
    //private GameObject PLAYER;

    public float waitForSeconds = 1f;

    [SerializeField] private string toScene;
    private Scene activeScene;  

    private GameObject ConditionChecker;
    private ConditionChecker condition;
    private int timesPortalWasUsed;
    public AudioSource portalEnteringSound;

    private float delayForSeconds = 1.0f;

    private Animator player_animator;

    private PlayerMovement mainPlayerScript;

   //private Animator letterAnimator;

    void Start()
    {
        ConditionChecker = GameObject.FindGameObjectWithTag("ConditionChecker");
        condition = ConditionChecker.GetComponent<ConditionChecker>();
        //letterAnimator = GameObject.FindGameObjectWithTag("Letter").GetComponent<Animator>();
        player_animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        mainPlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }  

    IEnumerator Delay(float delay_seconds)
    {
        yield return new WaitForSeconds(delay_seconds);
    }

    void Update()
    {
        timesPortalWasUsed = condition.GetNumerOfTimesPortalWasUsed();
        sceneTransitionCanvas = GameObject.FindGameObjectWithTag("SceneTransitionCanvas");
       
        if (isInteractable && Input.GetButtonDown("Use"))
        {
            if (condition.GetNumerOfTimesPortalWasUsed() != 2) {
                isUsePressed = true;

                condition.PortalWasUsed();
                condition.SceneSwitched();
                condition.stopTestPortalObjective();

                sceneTransitionCanvas.GetComponent<Animator>().SetBool("isEnteringScene", true);
                player_animator.SetTrigger("openPortal");
           
                //mainPlayerScript.enabled = false;
                condition.delay_player(2.0f);

                portalEnteringSound.Play();
            }
        } 

        else isUsePressed = false;

        if (isInteractable && Input.GetButtonDown("Description") && timesPortalWasUsed <= 3)
        {
            descriptionAnimator.SetBool(descritpionBoolTrigger, true);
        }
        else if(isInteractable == false)
        {
            descriptionAnimator.SetBool(descritpionBoolTrigger, false);
        }


        
    }

    IEnumerator TransitionToScene(float delay, string to_Scene)
    {
        if(isInteractable && Input.GetButtonDown("Use"))
        {
            Debug.Log("Transition animation should be running.");
            sceneTransitionCanvas.GetComponent<Animator>().SetBool("isEnteringScene", true);
        } 
        else
        {
            sceneTransitionCanvas.GetComponent<Animator>().SetBool("isEnteringScene", false);
        }

        yield return new WaitForSeconds(delay);
        InteractWithPortalToScene(to_Scene);

    }
    
    IEnumerator TransitionToSceneByIndex(float delay, int scene_index)
    {
        if(isInteractable && Input.GetButtonDown("Use"))
        {
            Debug.Log("Entering scene Animation.");
            sceneTransitionCanvas.GetComponent<Animator>().SetBool("isEnteringScene", true);
        }

        yield return new WaitForSeconds(delay);
        InteractWithPortalToSceneByIndex(scene_index);
    }

    void InteractWithPortalToScene(string ToScene)
    {
        if(isInteractable && Input.GetButtonDown("Use"))
        {   
            condition.SceneSwitched();
            condition.PortalWasUsed();
            isUsePressed = true;
            SceneManager.LoadScene(ToScene);
        }
        else
        {
            isUsePressed = false;
        }
    }

    void GoToSceneByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    void GoToScene(string toScene)
    {
        SceneManager.LoadScene(toScene);
    }

    void InteractWithPortalToSceneByIndex(int sceneIndex)
    {
        if(isInteractable && Input.GetButtonDown("Use"))
        {   
            condition.PortalWasUsed();
            condition.SceneSwitched();
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
            //letterAnimator.SetBool("isInteractable", true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInteractable = false;
            //letterAnimator.SetBool("isInteractable", false);

        }
    }

    public bool GetIsUsedPressed() { return isUsePressed; }

}
