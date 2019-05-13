using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDON : MonoBehaviour
{
    void Awake()
    {
        GameObject[] doors = GameObject.FindGameObjectsWithTag("doorOne");
        GameObject[] doorsTwo = GameObject.FindGameObjectsWithTag("doorTwo");

        if(doors.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
