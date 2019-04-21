using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalDescriptionPositionControl : MonoBehaviour
{
    public Transform DescriptionLocation;

    void Start()
    {
        
    }

    void Update()
    {
        if(DescriptionLocation.position.x >= 15) 
        {
            DescriptionLocation.position = new Vector3(DescriptionLocation.position.x - 5,
            DescriptionLocation.position.y, DescriptionLocation.position.z);
        }
    }

    // void OnTriggerEnter2D(Collider2D coll) 
    // {
    //     Debug.Log("HIT!");

    //     if(coll.gameObject.tag == "RightWall") 
    //     {
    //         Debug.Log("Right Wall HIT!");
    //         isHitRightWall = true;
    //     }
    //     if(coll.gameObject.tag == "LeftWall")
    //     {
    //         isHitLeftWall = true;
    //     }
    // }

    // void OnTriggerExit2D(Collider2D coll)
    // {
    //      if(coll.gameObject.tag == "RightWall") 
    //     {
    //         isHitRightWall = false;
    //     }
    //     if(coll.gameObject.tag == "LeftWall")
    //     {
    //         isHitLeftWall = false;
    //     }
    // }
}
