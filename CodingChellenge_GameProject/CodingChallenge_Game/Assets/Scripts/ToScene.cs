using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToScene : MonoBehaviour
{
    public InputField inputField;
    private PlayerMovement playerMovementScript;
    private InstantiatePortal portal;
    public Animator door1Animator;
    public Animator camera2Animator;

    void Start() {
        if(door1Animator == null) 
            door1Animator = GameObject.Find("door_1").GetComponent<Animator>();

        if(camera2Animator == null)
            camera2Animator = GameObject.Find("camera_2").GetComponent<Animator>();
        playerMovementScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        portal = GameObject.FindGameObjectWithTag("Player").GetComponent<InstantiatePortal>();
    }

    void Update()
    {
    }

    public void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void SelectInputField() 
    {
        inputField.ActivateInputField();
        inputField.Select();
        Debug.Log("Active Input field: " + inputField.isFocused);
    }

    public void OpenDoorOne()
    {
        door1Animator.SetTrigger("openDoor");
    }
    
    // public void EnablePlayer()
    // {
    //     playerMovementScript.enabled = true;
    // }

    // public void DisablePlayer()
    // {
    //     playerMovementScript.enabled = false;
    // }

    // public void DisablePortal()
    // {
    //     portal.enabled = false;
    //     Debug.Log("Portal: " + portal + portal.enabled);
    // }

    // public void EnablePortal()
    // {
    //     portal.enabled = true;
    // }

    public void killCameraTwo()
    {
        camera2Animator.SetBool("killCamera", true);
    }
}
