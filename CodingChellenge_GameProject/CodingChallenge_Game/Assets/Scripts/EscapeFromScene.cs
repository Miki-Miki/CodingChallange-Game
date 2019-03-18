using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeFromScene : MonoBehaviour
{
    public Animator anim;
    public string enterTrigger;
    public string exitTrigger;
    private bool isEscapePressed;
    private bool isUsedPressed;

    
    // Update is called once per frame
    void Update()
    {
        anim.SetBool(enterTrigger, isUsedPressed);
        anim.SetBool(exitTrigger, isEscapePressed);
        if (Input.GetButtonDown("Cancel"))
        {
            isEscapePressed = true;
        }
        else
        {
            isEscapePressed = false;
        }

        if(Input.GetButtonDown("Use"))
        {
            isUsedPressed = true;
        }
        else
        {
            isUsedPressed = false;
        }
    }
}
