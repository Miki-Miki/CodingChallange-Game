﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadInside : MonoBehaviour
{
    private GameObject Player;
    public GameObject door1, door2, door3;
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
        door1.transform.position = new Vector3(114f, -2.58f, -4.9f);
        door2.transform.position = new Vector3(140.6f, -2.54f, -4.9f);
        door3.transform.position = new Vector3(196.98f, -2.48f, -6.490003f);
        GameOverCanvas.SetActive(false);
        
    }
}
