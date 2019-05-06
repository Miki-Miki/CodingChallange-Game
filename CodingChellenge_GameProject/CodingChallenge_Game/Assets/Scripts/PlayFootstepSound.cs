using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayFootstepSound : MonoBehaviour
{
    
    public AudioSource footstep_one;
    public AudioSource footstep_two;
    public AudioClip carpetFootstepOne;
    public AudioClip carpetFootstepTwo;
    public AudioClip outdoorsFootstepOne;
    public AudioClip outdoorsFootsteptwo;
    public AudioClip insideFootsteopOne;
    public AudioClip insideFootstepTwo;

    private Scene currentScene;

    void Update() 
    {
        currentScene = SceneManager.GetActiveScene();
        
        if(currentScene.buildIndex == 1 || currentScene.buildIndex == 2)
        {
            footstep_one.clip = carpetFootstepOne;
            footstep_two.clip = carpetFootstepTwo;
        }

        if(currentScene.buildIndex == 3 || currentScene.buildIndex == 4)
        {
            footstep_one.clip = outdoorsFootstepOne;
            footstep_two.clip = outdoorsFootsteptwo;
        }

        if(currentScene.buildIndex == 6 || currentScene.buildIndex == 7)
        {
            footstep_one.clip = insideFootsteopOne;
            footstep_two.clip = insideFootstepTwo;
        }
    }

    public void play_footstep_one() 
    {
        footstep_one.Play();
    }

    public void play_footstep_two() 
    {
        footstep_two.Play();
    }
}
