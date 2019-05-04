using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class PlayDelayedLoop : MonoBehaviour
{
    public AudioSource first;
    public AudioSource looped;
    public float offset;

    void Start()
    {
        first.Play();
        looped.loop = true;
        //StartCoroutine(play_delayed(looped));
        looped.PlayDelayed(first.clip.length - offset);
    }

    IEnumerator play_delayed(AudioSource audio_source) {
        yield return new WaitForSeconds(offset);
        audio_source.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
