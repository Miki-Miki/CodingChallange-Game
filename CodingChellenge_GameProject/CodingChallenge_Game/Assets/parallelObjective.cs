using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallelObjective : MonoBehaviour
{
    public Animator onLoadObjective;
    private ConditionChecker condition;
    ////void Start()
    //{
    //    condition = GameObject.FindGameObjectWithTag("ConditionChecker").GetComponent<ConditionChecker>();
    //}

    // Update is called once per frame
    void Update()
    {
        condition = GameObject.FindGameObjectWithTag("ConditionChecker").GetComponent<ConditionChecker>();
        if (condition.getFirstTimeInPrallel() == false)
        {
            onLoadObjective.SetBool("isObjectiveAvailible", true);
            condition.setFirstTimeInParallel(true);
            StartCoroutine(completeObjective(5f));
        }
    }

    IEnumerator completeObjective(float delay)
    {
        yield return new WaitForSeconds(delay);
        onLoadObjective.SetBool("isObjectiveComplete", true);

    }
}
