using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDON : MonoBehaviour
{
    void Awake()
    {
        GameObject[] doors = GameObject.FindGameObjectsWithTag("doorOne");
        GameObject[] doorsTwo = GameObject.FindGameObjectsWithTag("doorTwo");
        GameObject[] GOCanvases = GameObject.FindGameObjectsWithTag("GameOverScreen");

        if(doors.Length > 1)
        {
            Destroy(this.gameObject);
        }

        if(GOCanvases.Length > 1)
        {
            for(int i = 0; i < GOCanvases.Length - 1; i++)
            {
                Destroy(GOCanvases[i]);
            }
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
