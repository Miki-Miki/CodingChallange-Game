using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_dealouge : MonoBehaviour
{

    public GameObject canvas;
    private bool isTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Use"))
        {
            Debug.Log("E presesd");
        }

        if(isTrigger && Input.GetButtonDown("Description"))
        {
            canvas.GetComponent<Animator>().SetBool("for_fade_in", true);
        }

        if (isTrigger && Input.GetButtonDown("Cancel"))
        {
            canvas.GetComponent<Animator>().SetBool("for_fade_in", false);
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
