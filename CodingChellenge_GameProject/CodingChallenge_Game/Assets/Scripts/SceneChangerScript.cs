using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScript : MonoBehaviour
{
    public Animator animator;
    public string enterTrigger;
    public string exitTrigger;
    private bool isEscapePressed;
    private bool isUsePressed;
    private bool isInteractable;
    public int sceneIndex;
    public GameObject playerToDisable;
    public GameObject computerLight;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInteractable && Input.GetButtonDown("Description") && computerLight.GetComponent<Light>().enabled == true)
        {
            isUsePressed = true;
            animator.SetBool(enterTrigger, isUsePressed);
            playerToDisable.GetComponent<PlayerMovement>().enabled = false;
            isEscapePressed = false;
            animator.SetBool(exitTrigger, isEscapePressed);
        } 
        else
        {
            isUsePressed = false;
        }

        if(isInteractable && Input.GetButtonDown("Cancel"))
        {
            isEscapePressed = true;
            animator.SetBool(exitTrigger, isEscapePressed);
            playerToDisable.GetComponent<PlayerMovement>().enabled = true;
            isUsePressed = false;

            animator.SetBool(enterTrigger, isUsePressed);
        }
        else
        {
            isEscapePressed = false;
        }
        
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
    
