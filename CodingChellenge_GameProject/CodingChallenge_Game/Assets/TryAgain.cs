using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryAgain : MonoBehaviour
{
    public Animator GameOverCanvas;
    private bool buttonClicked;

    void Update()
    {
        if(Input.GetButtonDown("Use"))
        {
            GameOverCanvas.SetBool("isGameOver", false);
            //GameOverCanvas.gameObject.SetActive(false);
        }

    }
    public void exitCanvas()
    {
        GameOverCanvas.SetBool("isGameOver", false);
    }
}
