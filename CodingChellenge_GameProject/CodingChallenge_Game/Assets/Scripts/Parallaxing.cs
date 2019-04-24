using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{

    public Transform[] backgrounds;
    private float[] parallaxScales;
    public float smoothing = 1f;

    private Transform cam;
    private Vector3 previosCamPosition;

    //private Transform foreground;

    void Awake()
    {
        cam = Camera.main.transform;
    }

    void Start()
    {
        // foreground = GameObject.FindGameObjectWithTag("Foreground").transform;
        // if(foreground != null)
        //     backgrounds[0] = foreground;

        previosCamPosition = cam.position;

        parallaxScales = new float[backgrounds.Length];

        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z * -1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
        
            float parallax = (previosCamPosition.x - cam.position.x) * parallaxScales[i];
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            //Creating new vecter 3 on background target position x, whish is defined
            //by the previous position + parallax
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //The new background position is a lerp (smooth transition) between the intial position
            //and the target position, all regulated or timed by 'smoothing'
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);

        }

        previosCamPosition = cam.position;
    }
}
