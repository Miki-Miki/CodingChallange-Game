using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    private bool isInteractable;
    public GameObject mainObject;
    public GameObject light;
    //public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
        light.GetComponent<Light>().enabled = false;
        isInteractable = false;

    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetBool("isForAnimation", isInteractable);
        if (isInteractable == true && Input.GetButtonDown("Use"))
        {
            Debug.Log("E is pressed");
            if (light.GetComponent<Light>().enabled == false)
            {
                light.GetComponent<Light>().enabled = true;
            }
            else if (light.GetComponent<Light>().enabled == true)
            {
                light.GetComponent<Light>().enabled = false;
            }

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Collision with Player");
            isInteractable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player exited the collider");
            isInteractable = false;
        }
    }


}
