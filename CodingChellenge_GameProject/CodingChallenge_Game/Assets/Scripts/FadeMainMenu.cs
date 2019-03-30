using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeMainMenu : MonoBehaviour
{

    public GameObject playButton;
    public GameObject exitButton;

    public void LoadScene()
    {
        SceneManager.LoadScene("Scene1");
    }
    
    public void DisableGameObject()
    {
        playButton.SetActive(false);
        exitButton.SetActive(false);
    }
}
