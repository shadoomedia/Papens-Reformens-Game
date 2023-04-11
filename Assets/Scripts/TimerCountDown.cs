using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerCountDown : MonoBehaviour
{
     TextMeshProUGUI timer;
    public float minutes = 2;
    public float seconds = 0;
    public float miliseconds = 0;
    public AudioSource tenSecondsLeftSound;
    public AudioSource fiveSecondsLeftSound;
    PlayerDeath playerDeath;
    public GameObject player;
    public GameObject timesUpUI;
    bool onetime = false;

    private void Start()
    {
        timer = GetComponent<TextMeshProUGUI>();
        
    }

    public void Awake()
    {
       
        playerDeath = player.GetComponent<PlayerDeath>();
        onetime = false;
        timesUpUI = GameObject.FindWithTag("timesup");
        timesUpUI.SetActive(false);
    }

    void Update()
    {

        if (miliseconds <= 0)
        {
            if (seconds <= 0)
            {
                minutes--;
                seconds = 59;
            }
            else if (seconds >= 0)
            {
                seconds--;
            }

            miliseconds = 100;
        }

        miliseconds -= Time.deltaTime * 100;

        //Debug.Log(string.Format("{0}:{1}:{2}", minutes, seconds, (int)miliseconds));
        timer.SetText(minutes + ":" + seconds + ":" + Mathf.Round(miliseconds));

        if (minutes == -1 && onetime == false)
        {

            //Debug.Log("seconds equals 0");
                      
            fiveSecondsLeftSound.Stop();
            playerDeath.Die();
            onetime = true;
            

        }

        if (onetime == true)
        {
            timer.SetText("0:0:00");
            Invoke("timesUP", 0.5f);
        }


        if (minutes == 0 && seconds == 10 && tenSecondsLeftSound.isPlaying == false)
        {
            timer.color = Color.yellow;
            tenSecondsLeftSound.Play();
        }
        if (minutes == 0 && seconds == 5 && fiveSecondsLeftSound.isPlaying == false)
        {
            timer.color = Color.red;
            tenSecondsLeftSound.Stop();
            fiveSecondsLeftSound.Play();
            
        }

        



    }
    void timesUP()
    {
        timesUpUI.SetActive(true);
    }

    
    

}


// quando o timer chega a 0, fica a 0, times up, reset
// quando chega à finish line,  guarda o valor do timer quando colide, continua o timer
//      armazenar variaveis com playerPrefs