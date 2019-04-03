using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstantiatePortal : MonoBehaviour
{
    public Transform portalSpawnPoint;
    public GameObject portal;
    public Scene parallel;
    private bool isF_pressed = false;
    public Animator portalAnimator;
    private Scene activeScene;

    private GameObject ConditionChecker;
    private ConditionChecker condition;

    void Start()
    {
        activeScene = SceneManager.GetActiveScene();
        ConditionChecker = GameObject.FindGameObjectWithTag("ConditionChecker");
        condition = ConditionChecker.GetComponent<ConditionChecker>();
    }
    // Update is called once per frame
    void Update()
    {
       
        if(Input.GetButtonDown("InstantiatePortal") && isF_pressed == false
            && SceneManager.GetActiveScene() != parallel && activeScene.buildIndex > 0
            && condition.GetComputerScreenOpened() == true)
        {
            isF_pressed = true;
            Instantiate_Portal();
            Debug.Log("F is pressed portal should be instantiated" + condition.GetComputerScreenOpened());
            Debug.Log("ComputerScreenOpened: " + condition.GetComputerScreenOpened());
        }
    }

    void Instantiate_Portal()
    {
        portalAnimator.SetTrigger("portalTrigger");
       
        Instantiate(portal, portalSpawnPoint.position, portalSpawnPoint.rotation);
    }
}
