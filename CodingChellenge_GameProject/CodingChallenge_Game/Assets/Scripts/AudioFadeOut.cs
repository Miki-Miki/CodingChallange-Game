using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeOut : MonoBehaviour
{
    public static IEnumerator FadeOut (AudioSource audioSource, float FadeTime) {
        float startVolume = audioSource.volume;
        float adjusetVolume = startVolume;
 
        while (adjusetVolume > 0) {
            adjusetVolume -= startVolume * Time.deltaTime / FadeTime;
            audioSource.volume = adjusetVolume;
            Debug.Log("Adjusted volume: " + adjusetVolume);
            yield return null;
        }
 
        audioSource.Stop ();
        audioSource.volume = startVolume;
    }
}
