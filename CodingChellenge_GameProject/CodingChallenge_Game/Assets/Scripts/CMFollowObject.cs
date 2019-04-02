using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CMFollowObject : MonoBehaviour
{
   
    public GameObject player;
    public Transform followTarget;
    private CinemachineVirtualCamera cmCAM;

    void Start()
    {
        cmCAM = GetComponent<CinemachineVirtualCamera>();

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        followTarget = player.transform;
        cmCAM.LookAt = followTarget;
        cmCAM.Follow = followTarget;
    }
}

