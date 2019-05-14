﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform cam;
    public GameObject Object;
    public GameObject buzz;

    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        if(buzz != null) {
            buzz.GetComponent<AudioSource>().PlayDelayed(28.0f);
            PlayBuzzAnimDelayed(30.0f);
        }
    }

    void FixedUpdate()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        Object.transform.position = Vector3.Lerp(Object.transform.position, cam.position, Time.deltaTime * 7);
    }

    IEnumerator delay_buzz_animation(float delay) {
        yield return new WaitForSeconds(delay);
        buzz.GetComponent<Animator>().SetTrigger("setAnim");
    }

    void PlayBuzzAnimDelayed(float seconds)
    {
        StartCoroutine(delay_buzz_animation(seconds));
    }
}