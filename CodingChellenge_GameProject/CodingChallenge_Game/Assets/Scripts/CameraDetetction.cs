﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetetction : MonoBehaviour
{
    //private GameObject GameOverScreen;
    public GameObject GameOverCanvas;
    private bool isGameOver = false;

    void Update()
    {
        GameOverCanvas = GameObject.FindGameObjectWithTag("GameOverCanvas");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has entered vision");
            isGameOver = true;
            GameOverCanvas.GetComponent<Animator>().SetBool("isGameOver", true);
        }
    }
}
