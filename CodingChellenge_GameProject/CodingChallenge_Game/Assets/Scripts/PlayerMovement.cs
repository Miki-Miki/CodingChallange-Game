using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private GameObject player;

    public Animator animator;
    public float pWalkSpeed = 20f;
    public float pRunSpeed = 70f;
    public float pCrouchSpeed = 300f;
    Rigidbody2D rb2d;
    public float scaleX;        //These scale attributes allow for the object to be resized
    public float scaleY;        //and not affected by the movement since in the block where we define the
    public float scaleZ;        //sprite flipping when player moves to the right we have to define the scale
    private bool isWalking;     //This way we ensure it is always the same
    public string boolTrigger;

   // private bool isForCrouchAnim;
    private bool cPresesed;

   
    //Controllers for fast walking while shift is pressed
    private bool isShiftPressed;
    public string boolShiftPressed;
    //public GameObject torsoObject;

    private Scene activeScene;
    private Scene currentScene;
    private DontDestroyObjOnLoad ObjectPreservingScript;
    private InstantiatePortal instantiatePortalScript;

    private GameObject ConditionChecker;
    private ConditionChecker condition;

    private bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        activeScene = SceneManager.GetActiveScene();
        instantiatePortalScript = GetComponent<InstantiatePortal>();
        ObjectPreservingScript = GetComponent<DontDestroyObjOnLoad>();
        rb2d = GetComponent<Rigidbody2D>();     //Grabbing teh RigidBody2D component from the object
        ConditionChecker = GameObject.FindGameObjectWithTag("ConditionChecker");
        condition = ConditionChecker.GetComponent<ConditionChecker>();
    }


    //This function runs every frame
    void Update()
    {   
        currentScene = SceneManager.GetActiveScene();

        if (activeScene.buildIndex == 0)
        {
            instantiatePortalScript.enabled = false;
            this.enabled = false;
        }
        else
        {
            instantiatePortalScript.enabled = true;
            ObjectPreservingScript.enabled = true;
            this.enabled = true;
        }

        if (Input.GetAxis("Horizontal") < -0.3f || Input.GetAxis("Horizontal") > 0.1f)  //If player is moving on the H - Axis
        {
            isWalking = true;
            animator.SetBool(boolTrigger, isWalking);
        }
        else
        {
            isWalking = false;
            animator.SetBool(boolTrigger, isWalking);
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

        if (Input.GetKeyDown("left shift") && cPresesed == false)
        {
            isShiftPressed = true;
            animator.SetBool(boolShiftPressed, isShiftPressed);
            pWalkSpeed = pRunSpeed;
        }
        
        if (Input.GetKeyUp("left shift") && cPresesed == false)
        {
            isShiftPressed = false;
            animator.SetBool(boolShiftPressed, isShiftPressed);
            pWalkSpeed = 55f;
        }

        if (Input.GetKeyDown("c") && isShiftPressed == false)
        {
            cPresesed = true;
            animator.SetBool("cPressed", true);
            pWalkSpeed = pCrouchSpeed;

            if(isWalking == true && isShiftPressed == false)
            {
                pWalkSpeed = pCrouchSpeed;
            }
        }

        if (Input.GetKeyUp("c"))
        {
            animator.SetBool("cPressed", false);
            animator.SetBool("isForCrouchAnimantion", false);
            pWalkSpeed = 55f;
            cPresesed = false;
        }

        if (currentScene.buildIndex == 3 && flag == true) 
        {
            scaleX = 0.6f;
            scaleY = 0.6f;
            scaleZ = 1f;
            transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
            pWalkSpeed = pWalkSpeed - 20f;
            pRunSpeed = pRunSpeed - 20f;
            flag = false;
        }

       // animator.SetBool(boolTrigger, isWalking);                       //Setting the bool that triggers the animation at every frame
                                                                            //Once it is true the animation will run or not depending on the bool value
        //if(condition.getExitingRoom() == true) destroyPlayer(1.0f, player);                                                                    
    }                                                                       

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

    IEnumerator delay_destruction(float seconds, GameObject objectToDestroy) {
        yield return new WaitForSeconds(seconds);
        Destroy(objectToDestroy);
    }

    public void destroyPlayer(float seconds, GameObject playerObject) { StartCoroutine(delay_destruction(seconds, playerObject)); }

}
