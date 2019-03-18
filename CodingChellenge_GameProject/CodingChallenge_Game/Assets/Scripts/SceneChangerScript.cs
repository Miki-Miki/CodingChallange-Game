using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerScript : MonoBehaviour
{
    public Animator animator;
    public string boolTrigger;
    private bool isInteractable;
    private bool readyForAnim;
    public int sceneIndex;
    public GameObject playerToDisable = null;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInteractable && Input.GetButtonDown("Use"))
        {
            readyForAnim = true;
            animator.SetBool(boolTrigger, isInteractable);
            playerToDisable.GetComponent<PlayerMovement>().enabled = false;
        } 
        else
        {
            readyForAnim = false;
        }

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("FadeOutScene"))
        {
            LoadScene(sceneIndex);
        }
    }

    void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInteractable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInteractable = false;
        }
    }
}
    
