using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterPopUp : MonoBehaviour
{
    public Animator animator;
    public string boolTrigger;
    private bool isTrigger = false;
    public float delay;

    

    void Update()
    {
        runCoroutine();
    }

    //This coroutine delays the triggering of an animation
    IEnumerator Delay(float seconds_delay)
    {
        yield return new WaitForSeconds(seconds_delay);
        animator.SetBool(boolTrigger, isTrigger);
    }

    void runCoroutine()
    {
        if (isTrigger == true)
        {
            StartCoroutine(Delay(delay));
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isTrigger = false;
        }
    }
}
