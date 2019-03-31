using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeMainMenu : MonoBehaviour
{
    public Animator animator;
    public Button playButton;
    public Button exitButton;

    void OnEnable() 
    {
        playButton.onClick.AddListener(RunFadeAnimation);
        exitButton.onClick.AddListener(ExitGame);
    }
    
    public void LoadScene()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void RunFadeAnimation() 
    {
        animator.SetBool("playPressed", true);
    }

    public void ExitGame() 
    {
        Application.Quit();
    }
}
