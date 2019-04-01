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
    private GameObject playerToDisable;
    private Transform player;
    private GameObject PLAYER;
    [SerializeField] private string toScene;
    private SceneController sceneController;


    void Start()
    {
        sceneController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(isInteractable && Input.GetButtonDown("Use"))
        {   
            isUsePressed = true;
            sceneController.LoadScene(toScene);
        }
        else
        {
            isUsePressed = false;
        }

        if(isInteractable && Input.GetButtonDown("Description"))
        {
            Debug.Log("Q pressed and is interactable");
            descriptionAnimator.SetBool(descritpionBoolTrigger, true);
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
