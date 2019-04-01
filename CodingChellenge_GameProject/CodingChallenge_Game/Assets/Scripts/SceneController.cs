using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string prevScene = "";
    public string currentScene = "";
    public Transform Player;
    public float player_X;
    public float player_Y;
    public float player_Z;
    

    public virtual void Start() {
        // Meant to be extended/overwritten by a scene script
        currentScene = SceneManager.GetActiveScene().name;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        //Debug.Log("X: " + Player.position.x + ",  Y:" + Player.position.y);
        player_X = Player.position.x;
        player_Y = Player.position.y;
        player_Z = Player.position.z;
    }
 
    public void LoadScene(string sceneName) {
        prevScene = currentScene;
        SceneManager.LoadScene(sceneName);
    }
}
