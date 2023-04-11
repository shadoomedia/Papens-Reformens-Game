using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagHit : MonoBehaviour
{
    public GameObject timer;
    public AudioSource winning;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerMain")
        {
            float minutes = timer.GetComponent<TimerCountDown>().minutes;
            float seconds = timer.GetComponent<TimerCountDown>().seconds;
            float miliseconds = timer.GetComponent<TimerCountDown>().miliseconds;
            //Debug.Log(mins +" :" +  secs + " :" + millis);
            PlayerPrefs.SetFloat("minutes", minutes);
            PlayerPrefs.SetFloat("seconds", seconds);
            PlayerPrefs.SetFloat("milisecs", Mathf.Round(miliseconds));
            winning.Play();

            StartCoroutine(WaitForSceneLoad());
            
        }
    }
    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    
}
