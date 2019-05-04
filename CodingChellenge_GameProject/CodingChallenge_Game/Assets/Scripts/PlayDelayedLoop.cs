using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class PlayDelayedLoop : MonoBehaviour
{
    public AudioClip first;
    public AudioClip looped;
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.clip = first;
        audio.Play();
        audio.clip = looped;
        audio.PlayDelayed(first.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
