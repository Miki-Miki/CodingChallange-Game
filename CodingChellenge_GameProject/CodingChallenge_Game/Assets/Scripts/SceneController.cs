using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string prevScene = "";
    public string currentScene = "";
    public Transform Player;
    
    public virtual void Start() {
        // Meant to be extended/overwritten by a scene script
        currentScene = SceneManager.GetActiveScene().name;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

   
 
    public void LoadScene(string sceneName) {
        prevScene = currentScene;
        SceneManager.LoadScene(sceneName);
    }
}
