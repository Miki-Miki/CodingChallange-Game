using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitioning : MonoBehaviour
{
    public void TransitionToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    
}
