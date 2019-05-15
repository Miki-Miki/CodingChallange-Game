using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkToPeople : MonoBehaviour
{
    public Animator objective;
    private ConditionChecker condition;
    private bool objComplete = false;

    void Start()
    {
        condition = GameObject.FindGameObjectWithTag("ConditionChecker").GetComponent<ConditionChecker>();
    }

    void Update()
    {
        if(!objComplete) objective.SetBool("isObjectiveComplete", false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            objective.SetBool("isObjectiveAvailible", true);
            StartCoroutine(completeObjective(4f));
            objComplete = false;
        }
    }

    IEnumerator completeObjective(float delay)
    {
        yield return new WaitForSeconds(delay);
        objective.SetBool("isObjectiveComplete", true);
        objComplete = true;

    }

    IEnumerator completeObjective2(float delay)
    {
        yield return new WaitForSeconds(delay);
        objective.SetBool("isObjectiveComplete", true);
        objComplete = true;

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            objective.SetBool("isObjectiveAvailible", true);
            StartCoroutine(completeObjective2(7f));
        }
    }

   
}
