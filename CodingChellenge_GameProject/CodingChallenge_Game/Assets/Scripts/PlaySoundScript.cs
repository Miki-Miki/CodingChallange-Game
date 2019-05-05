using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundScript : MonoBehaviour
{
    public AudioSource audio_source;
    public AudioSource main_menu_first;
    public AudioSource main_menu_loop;

    public void PlaySound()
    {
        audio_source.Play();
    }

    public void PauseSound()
    {
        audio_source.Pause();
    }

    public void FadeOutSound()
    {
        if(main_menu_first != null)
            StartCoroutine(AudioFadeOut.FadeOut(main_menu_first, 4f));
        
        if(main_menu_loop != null)
            StartCoroutine(AudioFadeOut.FadeOut(main_menu_loop, 4f));
    }
}
