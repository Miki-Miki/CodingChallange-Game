using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_disable : MonoBehaviour
{
    private PlayerMovement playerScript;
    private InstantiatePortal portalScript;
    private GameObject Player;
    private Animator playerAnimator;

    void Start() 
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        portalScript = Player.GetComponent<InstantiatePortal>();
        playerScript = Player.GetComponent<PlayerMovement>();
        playerAnimator = Player.GetComponent<Animator>();
    }

    void Update()
    {
        if(portalScript == null) Debug.Log("Can't find instantiate portal.");
        if(playerScript == null) Debug.Log("Can't find PlayerMovement.");
        if(Player == null) Debug.Log("Can't find player");

    }

    public void DisablePlayer()
    {
        playerAnimator.SetBool("ShiftPressed", false);
        playerAnimator.SetBool("isForAnimation", false);
        playerAnimator.SetBool("isForCrouchAnimation", false);
        playerAnimator.SetBool("cPressed", false);
       // Player.GetComponent<PlayerMovement>().standStill();
        playerScript.enabled = false;
    }

    public void EnablePlayer()
    {
        playerScript.enabled = true;
       // Player.GetComponent<PlayerMovement>().walk();
    }

    public void DisablePortal()
    {
        portalScript.enabled = false;
    }

    public void EnablePortal()
    {
        portalScript.enabled = true;
    }
}
