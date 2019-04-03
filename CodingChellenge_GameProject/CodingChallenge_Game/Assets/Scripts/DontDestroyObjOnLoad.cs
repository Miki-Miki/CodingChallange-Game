using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyObjOnLoad : MonoBehaviour
{

    private Scene activeScene;

    void Awake() 
    {   
        activeScene = SceneManager.GetActiveScene();

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");

        if(activeScene.buildIndex == 0 || activeScene.buildIndex == 1)
        {
            this.enabled = false;
        }

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

}
