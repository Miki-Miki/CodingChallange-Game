using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tryAgainButtonSetActive : MonoBehaviour
{
    public GameObject button;
    public void EnableTryAgainButton()
    {
        button.SetActive(true);
    }
    public void DisableTryAgainButton()
    {
        button.SetActive(false);
    }
}
