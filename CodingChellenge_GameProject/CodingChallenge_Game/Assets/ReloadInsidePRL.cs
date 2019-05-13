using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadInsidePRL : MonoBehaviour
{
    private GameObject Player;
    public GameObject GameOverCanvas;
    public GameObject cam1, cam2;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ReloadLevel()
    {
        if(cam1 != null)
            cam1.GetComponent<Animator>().SetBool("killCamera", false);

        if(cam2 != null)
            cam2.GetComponent<Animator>().SetBool("killCamera", false);

        Player.transform.position = new Vector3(105.65f, -1.94f, -4.340001f);
        Player.GetComponent<PlayerMovement>().enabled = true;
        GameOverCanvas.SetActive(false);
    }
}
