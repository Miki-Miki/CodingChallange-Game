using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float pWalkSpeed = 20f;
    Rigidbody2D rb2d;
    public float scaleX;
    public float scaleY;
    public float scaleZ;
    private bool isWalking;
    public string boolTrigger;

  
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();   
    }


     void Update()
    {

        if(Input.GetAxis("Horizontal") < -0.1f || Input.GetAxis("Horizontal") > 0.1f)
        {
            isWalking = true;
        } 
        else
        {
            isWalking = false;
        }

        //Turning the player sprite around it's pivot when it moves in x and -x
        if(Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-scaleX, scaleY, scaleZ);
        }
       

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
           
            transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        }
       

        animator.SetBool(boolTrigger, isWalking);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Grabbing horizontal and vertical input
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Easing down the rb's velocity
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.x *= 0.75f;                //dividing it's velocity by a certain ammount
        easeVelocity.y = rb2d.velocity.y;       //keeping the y velocity same not to ruin it
        easeVelocity.z = 0.0f;                  //we don't use z axis in 2d games

        rb2d.velocity = easeVelocity;

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement*pWalkSpeed);
        
        
    }
}
