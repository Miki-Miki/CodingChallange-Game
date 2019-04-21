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
    private GameObject[] existingPortal;

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
        existingPortal = GameObject.FindGameObjectsWithTag("Portal");
        if(existingPortal != null && isF_pressed == true 
            && Input.GetButtonDown("InstantiatePortal") 
            && SceneManager.GetActiveScene() != parallel 
            && activeScene.buildIndex > 0
            && condition.GetComputerScreenOpened() == true) {
                
                Debug.Log("Delete previous instantiate new (if block entered)");
                isF_pressed = false;
                
                for(int i = 0; i < existingPortal.Length; i++) {
                    Destroy(existingPortal[i]);
                }
                
                Instantiate_Portal();
                condition.PortalWasInstantiated();
            }

        if(Input.GetButtonDown("InstantiatePortal") && isF_pressed == false
            && SceneManager.GetActiveScene() != parallel && activeScene.buildIndex > 0
            && condition.GetComputerScreenOpened() == true)
        {
            isF_pressed = true;
            Instantiate_Portal();
            condition.PortalWasInstantiated();
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
