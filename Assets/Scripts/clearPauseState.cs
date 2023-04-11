using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearPauseState : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pause;

    // Start is called before the first frame update
    void Awake()
    {
        pause = GetComponent<GameObject>();

        if (GameIsPaused == true)
        {
            pause.SetActive(false);
        }
    }


}
