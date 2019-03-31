using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeMainMenu : MonoBehaviour
{
    public Animator animator;

    public void LoadScene()
    {
        SceneManager.LoadScene("Scene1");
    }
    
    void Update() 
    {
        
    }
}
