using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Terminal : MonoBehaviour
{
    private bool isInteractable;
    private DescriptionControl description;
    private GameObject SceneTransitionCanvas;

    void Start()
    {
        description = GetComponent<DescriptionControl>();
    }

    void Update()
    {
        if (description.GetTimesDescritpionWasPoped() > 0 && isInteractable &&
        Input.GetButtonDown("Use"))
        {
            SceneTransitionCanvas.GetComponent<Animator>().SetBool("toScene", true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
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

    public void ToScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
