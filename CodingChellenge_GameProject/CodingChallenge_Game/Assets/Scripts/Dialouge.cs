using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialouge : MonoBehaviour
{
    public TextMeshProUGUI textDispaly;
    public string[] answers;
    private int index;
    private int whichQuestion;
    public float typeSpeed;
    public GameObject[] questions;

    private void Start()
    {
       
    }
    private void Update()
    {
        if(textDispaly.text == answers[whichQuestion] || textDispaly.text == "") //if the sentence stoped writing itself then show questions
        {
            HideQuestions(true); // show
        }
    }

    IEnumerator Type() // Typing effect on answers
    {
        foreach(char letter in answers[whichQuestion].ToCharArray())
        {
            textDispaly.text += letter;
            yield return new WaitForSeconds(typeSpeed);

        }
    }

    public void answer(int answer)
    {
        HideQuestions(false); //hide

        switch (answer)
        {
            case 0: whichQuestion = 0; break;
            case 1: whichQuestion = 1; break;
            case 2: whichQuestion = 2; break;
        }
        textDispaly.text = "";
        StartCoroutine(Type());
    }

    private void HideQuestions(bool condition)
    {
        for (int i = 0; i < questions.Length; i++) //hide the questions when the sentence starts typing so as to not allow the player to spam it
            questions[i].SetActive(condition);
    }
}
