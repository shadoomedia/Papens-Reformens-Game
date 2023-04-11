using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePage : MonoBehaviour
{
    TextMeshProUGUI scoreboard;

    public void Awake()
    {

    
    float minutes = PlayerPrefs.GetFloat("minutes");
    float seconds = PlayerPrefs.GetFloat("seconds");
    float miliseconds = PlayerPrefs.GetFloat("milisecs");



    scoreboard = GetComponent<TextMeshProUGUI>();
    scoreboard.SetText("You passed the level with\n"+ minutes + ":" + seconds + ":" + miliseconds + " remaining!");
    }
}
