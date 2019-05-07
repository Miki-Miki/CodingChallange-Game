using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScene : MonoBehaviour
{
    public void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
