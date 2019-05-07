using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnLoadOfOutdoors : MonoBehaviour
{
    private Scene activeScene;
    static bool flag = true;
    public GameObject objectToDestroy;

    void Update()
    {
        activeScene = SceneManager.GetActiveScene();
        if(activeScene.buildIndex == 4 && flag == true) {
            Destroy(objectToDestroy);
            //flag = false;
        }
    }
}
