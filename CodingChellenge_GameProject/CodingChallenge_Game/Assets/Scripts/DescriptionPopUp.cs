using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionPopUp : MonoBehaviour
{
    public Animator animator;
    public string boolTrigger;
    private bool isTrigger;
    public GameObject computerLight;


    // Update is called once per frame
    void Update()
    {
        if (isTrigger && Input.GetButtonDown("Description")
            && computerLight.GetComponent<Light>().enabled == false)
        {
            animator.SetBool(boolTrigger, isTrigger);
        } 
        if (isTrigger == false || computerLight.GetComponent<Light>().enabled == true)
        {
            animator.SetBool(boolTrigger, false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isTrigger = false;
        }
    }
}
