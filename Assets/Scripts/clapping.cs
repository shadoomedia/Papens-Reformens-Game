using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clapping : MonoBehaviour    
{
   

    public AudioSource winningAudio1;
    public AudioSource winningAudio2;
    public AudioSource winningAudio3;
    public AudioSource winningAudio4;

    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerMain")
        {
            winningAudio1.Play();
            winningAudio2.Play();
            winningAudio3.Play();
            winningAudio4.Play();
        }
    }

}
