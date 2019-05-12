using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToScene : MonoBehaviour
{
    public InputField inputField;
    public Animator door1Animator;
    public Animator camera2Animator;
    public Transform door1Transform;
    public Animator door2Animator;

    private PlayerMovement playerMovementScript;
    private InstantiatePortal portal;

    void Start() 
    {
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

    public void OpenDoorTwo()
    {
        door2Animator.SetTrigger("openDoor");
    }
    
    public void keepDoorPosition() 
    {
        door1Transform.position = new Vector3(119.35f, 1.86f, -6.490003f);
    }

    public void killCameraTwo()
    {
        camera2Animator.SetBool("killCamera", true);
    }
}
