using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float pWalkSpeed = 20f;
    public float pRunSpeed = 70f;
    Rigidbody2D rb2d;
    public float scaleX;        //These scale attributes allow for the object to be resized
    public float scaleY;        //and not affected by the movement since in the block where we define the
    public float scaleZ;        //sprite flipping when player moves to the right we have to define the scale
    private bool isWalking;     //This way we ensure it is always the same
    public string boolTrigger;
   
    //Controllers for fast walking while shift is pressed
    private bool isShiftPressed;
    public string boolShiftPressed;
    //public GameObject torsoObject;

    private Scene activeScene;
    private DontDestroyObjOnLoad ObjectPreservingScript;
    private InstantiatePortal instantiatePortalScript;

    // Start is called before the first frame update
    void Start()
    {
        activeScene = SceneManager.GetActiveScene();
        instantiatePortalScript = GetComponent<InstantiatePortal>();
        ObjectPreservingScript = GetComponent<DontDestroyObjOnLoad>();
        rb2d = GetComponent<Rigidbody2D>();     //Grabbing teh RigidBody2D component from the object
    }


    //This function runs every frame
    void Update()
    {   

        if(activeScene.buildIndex == 0)
        {
            instantiatePortalScript.enabled = false;
        }
        else
        {
            instantiatePortalScript.enabled = true;
            ObjectPreservingScript.enabled = true;
        }

        if (Input.GetAxis("Horizontal") < -0.3f || Input.GetAxis("Horizontal") > 0.1f)  //If player is moving on the H - Axis
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        //Turning the player sprite around it's pivot when it moves in x and -x
        if (Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-scaleX, scaleY, scaleZ);    //By grabbing the player's transform and
        }                                                                   //transforming its scale when it moves to the left 


        if (Input.GetAxis("Horizontal") > 0.1f)
        {

            transform.localScale = new Vector3(scaleX, scaleY, scaleZ);     //While object moves to the right scale remains the same
        }

        if(Input.GetKeyDown("left shift"))
        {
            isShiftPressed = true;
            animator.SetBool(boolShiftPressed, isShiftPressed);
            pWalkSpeed = pRunSpeed;
        }
        
        if(Input.GetKeyUp("left shift"))
        {
            isShiftPressed = false;
            animator.SetBool(boolShiftPressed, isShiftPressed);
            pWalkSpeed = 55f;
        }

        animator.SetBool(boolTrigger, isWalking);                           //Setting the bool that triggers the animation at every frame
    }                                                                       //Once it is true the animation will run or not depending on the bool value

    // FixedUpdate is called every fixed frame-rate frame
    void FixedUpdate()
    {
        //Grabbing horizontal input (A, D, Right-Arrow, Left-Arrow)
        //If (A or Left-Arrow are pressed the Input.GetAxis("Horizontal") method will return a value between 0 and -1
        //if (D or Right-Arrow are pressed the Input.GetAxis("Horizontal") method will return a value between 0 and 1
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Easing down the rb's velocity
        Vector3 easeVelocity = rb2d.velocity;
        easeVelocity.x *= 0.75f;                //Dividing it's velocity by a certain ammount which will stop object from gliding
        easeVelocity.y = rb2d.velocity.y;       //Keeping the Y velocity same because we don't act on that axis
        easeVelocity.z = 0.0f;                  //We don't use Z axis in 2d games

        rb2d.velocity = easeVelocity;           //Setting the new velocity to our objects velocity

        Vector2 movement = new Vector2(moveHorizontal, 0);  //Creating a new Vector2 along the line where are player walks (or will walk)

        rb2d.AddForce(movement * pWalkSpeed);                 //Setting that vector as the vector that adds force on our object's rigid body component
                                                              //Multiplying that with our adjustable pWalkSpeed value we can adjust the objects moving speed

    }

    public void disablePlayer()
    {
        this.enabled = false;
    }

    public void enablePlayer()
    {
        this.enabled = true;
    }

}
