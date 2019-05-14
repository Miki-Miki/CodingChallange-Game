using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppenToCamera : MonoBehaviour
{
    private Transform cameraTransform;

   void Start()
    {
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void Update()
    {
        
    }
}
