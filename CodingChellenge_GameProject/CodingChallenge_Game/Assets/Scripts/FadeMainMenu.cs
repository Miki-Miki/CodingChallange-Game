using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeMainMenu : MonoBehaviour
{
    public Animator imageAnimator;
    public Animator canvasAnimator;
    public string boolTrigger;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(imageAnimator.GetCurrentAnimatorStateInfo(0).IsName("Pressed"))
        {
            canvasAnimator.SetBool(boolTrigger, true);
        }
    }
}
