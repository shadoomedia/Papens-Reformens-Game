using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitingelly : MonoBehaviour
{
    public AudioSource ellymusic;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerMain")
        {
            ellymusic.Play();
        }
    }
}
