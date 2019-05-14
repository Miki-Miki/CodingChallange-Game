using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWarning : MonoBehaviour
{
    public Animator cameraAnimator;
    public Animator cameraWarningObjective;

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
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        cameraWarningObjective.SetBool("isObjectiveComplete", false);
        if (hasEntered) StartCoroutine(cameraObjective(6f));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !hasEntered)
        {
            Debug.Log("Camera Warning!!!");
            isForWarning = true;
            cameraAnimator.SetTrigger("cameraWarning");
            //cameraWarningObjective.SetBool("isObjectiveComplete", false);
            cameraWarningObjective.SetBool("isObjectiveAvailible", true);
            //StartCoroutine(cameraObjective(3f));
            hasEntered = true;
        }
    }
    
    IEnumerator cameraObjective(float delay) 
    {
        yield return new WaitForSeconds(delay);
        cameraWarningObjective.SetBool("isObjectiveComplete", true);

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
