using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWarning : MonoBehaviour
{
    public Animator cameraAnimator;
    private CCInside condition;
    private PlayerMovement player;

    private CMFollowObject cmFollowScript;
    private bool hasEntered = false;

    private bool isForWarning;

    void Start()
    {
        condition = GameObject.FindGameObjectWithTag("ConditionChecker").GetComponent<CCInside>();
        cmFollowScript = GetComponent<CMFollowObject>();
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        if (hasEntered) cameraWarnignComplete(4f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !hasEntered)
        {
            //DisablePlayerDelayed(6f);
            isForWarning = true;
            condition.setIsForCamWarning(true);
            cameraAnimator.SetBool("cameraWarning", true);
            hasEntered = true;
        }
    }
    
    IEnumerator cameraObjective(float delay) 
    {
        yield return new WaitForSeconds(delay);
        condition.setIsForCamWarning(false);
    }

    private void cameraWarnignComplete(float delay)
    {
        StartCoroutine(cameraObjective(delay));
    }

    IEnumerator DisPlayer(float delay) 
    {
        player.enabled = false;
        cmFollowScript.enabled = false;
        yield return new WaitForSeconds(delay);
        player.enabled = true;
        cmFollowScript.enabled = true;
    }

    private void DisablePlayerDelayed(float delay)
    {
        StartCoroutine(DisPlayer(delay));
    }
}
