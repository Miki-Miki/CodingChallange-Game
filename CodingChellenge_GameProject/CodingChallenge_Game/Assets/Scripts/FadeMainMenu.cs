using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeMainMenu : MonoBehaviour
{
    public Animator animator;
    public Button playButton;

    void OnEnable() 
    {
        playButton.onClick.AddListener(runFadeAnimation);
    }
    
    public void LoadScene()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void runFadeAnimation() 
    {
        animator.SetBool("playPressed", true);
    }
}
