using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalMusic : MonoBehaviour
{

    [SerializeField] AudioSource gameMusic;

    // Start is called before the first frame update
    void Start()
    {
        gameMusic.loop = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
