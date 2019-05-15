using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shellTrigger : MonoBehaviour
{
    public Animator shellObjective;
    private ConditionChecker condition;

    void Start()
    {
        condition = GameObject.FindGameObjectWithTag("ConditionChecker").GetComponent<ConditionChecker>();
    }

    void Update()
    {
        condition = GameObject.FindGameObjectWithTag("ConditionChecker").GetComponent<ConditionChecker>();
        if(!condition.getFirstTimeInsideParallel())
        {
            shellObjective.SetBool("isObjectiveAvailible", true);
            condition.setFirstTimeInsideParallel(true);
            StartCoroutine(completeObjective(6f));
        }
    }

    IEnumerator completeObjective(float delay)
    {
        yield return new WaitForSeconds(delay);
        shellObjective.SetBool("isObjectiveComplete", true);

    }
}
