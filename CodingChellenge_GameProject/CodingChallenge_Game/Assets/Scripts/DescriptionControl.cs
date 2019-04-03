using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionControl : MonoBehaviour
{

    private bool isInteractable = false;
    public Animator animator;
    public string boolTrigger;

    // Update is called once per frame
    void Update()
    {
        if (isInteractable && Input.GetButtonDown("Descirption"))
        {
            animator.SetBool(boolTrigger, true);
        }
        else
        {
            animator.SetBool(boolTrigger, false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isInteractable = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInteractable = true;
        }
    }
}
