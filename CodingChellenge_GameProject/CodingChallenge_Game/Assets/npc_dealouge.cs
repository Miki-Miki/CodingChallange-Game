using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npc_dealouge : MonoBehaviour
{

    public GameObject canvas;
    private bool isTrigger;
    public GameObject dialogueSystem;
    public GameObject es1, es2;
    private ConditionChecker condition;
    private bool npc1 = true;
    private bool npc2 = true;


    // Start is called before the first frame update
    void Start()
    {
        condition = GameObject.FindGameObjectWithTag("ConditionChecker").GetComponent<ConditionChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        condition = GameObject.FindGameObjectWithTag("ConditionChecker").GetComponent<ConditionChecker>();

        if (Input.GetButtonDown("Use"))
        {
            Debug.Log("E presesd");
        }

        if(isTrigger && Input.GetButtonDown("Use"))
        {
            canvas.GetComponent<Animator>().SetBool("for_fade_in", true);
            dialogueSystem.active = true;
        }

        if (isTrigger && Input.GetButtonDown("Cancel"))
        {
            canvas.GetComponent<Animator>().SetBool("for_fade_in", false);
            dialogueSystem.active = false;
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
