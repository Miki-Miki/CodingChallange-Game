using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSet : MonoBehaviour
{

    public Animator animator;
    public string boolTrigger;
    private bool isInteractable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool(boolTrigger, isInteractable);   
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInteractable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInteractable = false;
        }
    }
}
