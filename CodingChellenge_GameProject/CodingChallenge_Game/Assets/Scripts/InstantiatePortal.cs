using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePortal : MonoBehaviour
{
    public Transform portalSpawnPoint;
    public GameObject portal;
    private bool isF_pressed = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("InstantiatePortal") && isF_pressed == false)
        {
            isF_pressed = true;
            Instantiate_Portal();
            Debug.Log("F is pressed portal should be instantiated");
        }
    }

    void Instantiate_Portal()
    {
        Instantiate(portal, portalSpawnPoint.position, portalSpawnPoint.rotation);
    }
}
