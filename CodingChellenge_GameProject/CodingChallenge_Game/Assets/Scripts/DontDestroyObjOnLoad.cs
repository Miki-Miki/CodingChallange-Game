using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyObjOnLoad : MonoBehaviour
{

    private Scene activeScene;
    public GameObject[] gameObjectsToDestroy;

    void Awake() 
    {   
        activeScene = SceneManager.GetActiveScene();

        if(gameObjectsToDestroy.Length > 0)
        {
            for(int i = 0; i < gameObjectsToDestroy.Length; i++)
            {
                Destroy(gameObjectsToDestroy[i]);
            }
        }


        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");

        if(activeScene.buildIndex == 1)
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
