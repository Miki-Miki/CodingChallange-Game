using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_disable : MonoBehaviour
{
    private PlayerMovement player;
    private InstantiatePortal portal;
    private GameObject Player;
    private Animator playerAnimator;

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        portal = GameObject.FindGameObjectWithTag("Player").GetComponent<InstantiatePortal>();
        Player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = Player.GetComponent<Animator>();

    }

    public void DisablePlayer()
    {
        playerAnimator.SetBool("ShiftPressed", false);
        playerAnimator.SetBool("isForAnimation", false);
        playerAnimator.SetBool("isForCrouchAnimation", false);
        playerAnimator.SetBool("cPressed", false);
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
