using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWarning : MonoBehaviour
{
    public Animator cameraAnimator;
    public Animator cameraWarningObjective;

    private CCInside condition;
    private PlayerMovement player;
    private CMFollowObject cmFollowScript;
    private bool hasEntered = false;

    private bool isForWarning;

    void Start()
    {
        cmFollowScript = GetComponent<CMFollowObject>();
    }

    void Update()
    {
        condition = GameObject.FindGameObjectWithTag("CCInside").GetComponent<CCInside>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        if (hasEntered) cameraWarnignComplete(4f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !hasEntered)
        {
            StartCoroutine(startObjective(5f));
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

    IEnumerator startObjective(float delay)
    {
        cameraWarningObjective.SetBool("isObjectiveAvailible", true);
        yield return new WaitForSeconds(delay);
        cameraWarningObjective.SetBool("isObjectiveComplete", true);
    }
}
