using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToScene : MonoBehaviour
{
    public InputField _inputField;
    public Animator door1Animator;
    private PlayerMovement playerMovementScript;
    private InstantiatePortal portal;

    void Update()
    {
        playerMovementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        portal = GameObject.FindGameObjectWithTag("Player").GetComponent<InstantiatePortal>();
    }

    public void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ActivateInputField() 
    {
        _inputField.Select();
    }

    public void OpenDoorOne()
    {
        door1Animator.SetTrigger("openDoor");
    }
    
    public void EnablePlayer()
    {
        playerMovementScript.enabled = true;
    }

    public void DisablePlayer()
    {
        playerMovementScript.enabled = false;
    }

    public void DisablePortal()
    {
        portal.enabled = false;
    }

    public void EnablePortal()
    {
        portal.enabled = true;
    }
}
