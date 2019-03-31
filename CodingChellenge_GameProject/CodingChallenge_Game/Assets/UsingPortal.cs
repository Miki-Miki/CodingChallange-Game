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
    public int sceneIndex = 0;
    public GameObject playerToDisable;

    // Update is called once per frame
    void Update()
    {
        if(isInteractable && Input.GetButtonDown("Use"))
        {   
            sceneIndex = 1;
            isUsePressed = true;
            LoadScene();
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

    void LoadScene() 
    {
        if(sceneIndex == 0)
            SceneManager.LoadScene(1);
        else
            SceneManager.LoadScene(3);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInteractable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInteractable = false;
        }
    }
}
