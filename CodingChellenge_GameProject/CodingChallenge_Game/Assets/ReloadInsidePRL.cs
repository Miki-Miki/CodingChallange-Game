using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadInsidePRL : MonoBehaviour
{
    private GameObject Player;
    public GameObject GameOverCanvas;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ReloadLevel()
    {
        Player.transform.position = new Vector3(105.65f, -1.94f, -4.340001f);
        Player.GetComponent<PlayerMovement>().enabled = true;
        GameOverCanvas.SetActive(false);
    }
}
