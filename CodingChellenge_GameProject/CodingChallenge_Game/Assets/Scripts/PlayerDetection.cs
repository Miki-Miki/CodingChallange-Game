﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDetection : MonoBehaviour
{
    public GameObject GameOverCanvas;
    private bool isGameOver = false;
    private Scene activeScene;

    void Update()
    {
        activeScene = SceneManager.GetActiveScene();
        // GameOverCanvas = GameObject.FindGameObjectWithTag("GameOverCanvas");
        if(isGameOver && activeScene.buildIndex != 7) GameOverCanvas.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has entered vision");
            isGameOver = true;
        }
    }


}
