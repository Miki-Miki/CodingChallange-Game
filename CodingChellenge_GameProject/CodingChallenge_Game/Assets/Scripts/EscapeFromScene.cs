using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeFromScene : MonoBehaviour
{
    public Animator anim;
    public string boolTrigger;
    private bool isEscapePressed = false;
    public int LoadSceneByIndex;
    
    // Update is called once per frame
    void Update()
    {
        anim.SetBool(boolTrigger, isEscapePressed);
        if (Input.GetButtonDown("Cancel"))
        {
            isEscapePressed = true;
        }
        else
        {
            isEscapePressed = false;
        }

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("FadeSceneToBlack"))
        {
            LoadScene(LoadSceneByIndex);
        }
    }

    void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
