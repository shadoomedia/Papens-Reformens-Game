using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class time : MonoBehaviour
{
    private void Awake()
    {
        if (Time.timeScale > 0) ;
        AudioListener.pause = false;
    }
}
