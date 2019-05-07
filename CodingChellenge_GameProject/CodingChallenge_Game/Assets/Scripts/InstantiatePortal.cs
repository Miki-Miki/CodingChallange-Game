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
    private static bool flag = true;

    void Start()
    {
        
        ConditionChecker = GameObject.FindGameObjectWithTag("ConditionChecker");
        
        if(ConditionChecker != null)
            condition = ConditionChecker.GetComponent<ConditionChecker>();
        
    }
    // Update is called once per frame
    void Update()
    {
        existingPortal = GameObject.FindGameObjectsWithTag("Portal");
        activeScene = SceneManager.GetActiveScene();

        if(condition.getExitingRoom() == true) {
           for(int i = 0; i < existingPortal.Length; i++) {
                    delay_destruction(1.0f, existingPortal[i]);
                } 
        }

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
            }

        if(Input.GetButtonDown("InstantiatePortal") && isF_pressed == false
            && SceneManager.GetActiveScene() != parallel && activeScene.buildIndex > 0
            && condition.GetComputerScreenOpened() == true)
        {
            isF_pressed = true;

            condition.portalWasInstantiated();

            if (condition.getNumberOfTimesPortalWasSpawned() == 1)
                condition.setPortalOpenedFirstTime();

            Instantiate_Portal();
            Debug.Log("F is pressed portal should be instantiated" + condition.GetComputerScreenOpened());
            Debug.Log("ComputerScreenOpened: " + condition.GetComputerScreenOpened());
        }

        if(activeScene.buildIndex == 4 && flag == true)
        {
            if(existingPortal != null) {
                for (int i = 0; i < existingPortal.Length; i++)
                {
                    Destroy(existingPortal[i]);
                    flag = false;
                }
            }
        }
    }

    void Instantiate_Portal()
    {
        portalAnimator.SetTrigger("portalTrigger");
       
        Instantiate(portal, portalSpawnPoint.position, portalSpawnPoint.rotation);
    }

    IEnumerator delay_destruction(float seconds, GameObject objectToDestroy) {
        yield return new WaitForSeconds(seconds);
        Destroy(objectToDestroy);
    }

    public void destroyPlayer(float seconds, GameObject playerObject) { StartCoroutine(delay_destruction(seconds, playerObject)); }

}
