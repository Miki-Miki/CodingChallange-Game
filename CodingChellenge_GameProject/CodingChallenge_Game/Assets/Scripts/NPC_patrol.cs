using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_patrol : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomSpot = 0;

    void Start()
    {
        waitTime = startWaitTime;
    }

    void Update()
    {
         transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (randomSpot == 1)
        {
            if (Vector2.Distance(transform.position, moveSpots[1].position) < 0.1f)
            {
                randomSpot = 0;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }


        if (randomSpot == 0)
        {  
            if (Vector2.Distance(transform.position, moveSpots[0].position) < 0.1f)
            {
                randomSpot = 1;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }

       
    }
}