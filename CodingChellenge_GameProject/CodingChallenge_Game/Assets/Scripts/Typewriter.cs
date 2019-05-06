using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour
{
    Text txt;
    string story;
    public bool PlayOnAwake = true;
    public float Delay;
    public float Speed = 0.1f;

    void Awake()
    {
        txt = GetComponent<Text>();
        if (PlayOnAwake)
            ChangeText(txt.text, Delay);
    }

    //Update text and start typewriter effect
    public void ChangeText(string _text, float _delay = 0f)
    {
        StopCoroutine(PlayText()); //stop Coroutime if exist
        story = _text;
        txt.text = ""; //clean text
        Invoke("Start_PlayText", _delay); //Invoke effect
    }

    void Start_PlayText()
    {
        StartCoroutine(PlayText());
    }

    IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            txt.text += c;
            yield return new WaitForSeconds(Speed);
        }
    }
}
