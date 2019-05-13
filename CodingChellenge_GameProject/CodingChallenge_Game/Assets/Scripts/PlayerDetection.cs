using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public GameObject GameOverCanvas;
    private bool isGameOver = false;

    void Update()
    {
        // GameOverCanvas = GameObject.FindGameObjectWithTag("GameOverCanvas");
        if(isGameOver) GameOverCanvas.SetActive(true);
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
