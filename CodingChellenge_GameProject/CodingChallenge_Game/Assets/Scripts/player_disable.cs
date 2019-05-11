using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_disable : MonoBehaviour
{
    private PlayerMovement player;
    private InstantiatePortal portal;

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        portal = GameObject.FindGameObjectWithTag("Player").GetComponent<InstantiatePortal>();


    }

    public void DisablePlayer()
    {
        player.enabled = false;
    }

    public void EnablePlayer()
    {
        player.enabled = true;
    }

    public void DisablePortal()
    {
        portal.enabled = false;
    }

    public void EnablePortal()
    {
        portal.enabled = true;
    }
}
