using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public void invokeNxtLvl()
    {
        Invoke("GoToNextLevel", 1.5f);
    }
    public void GoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GoToFirstLevel()
    {
        SceneManager.LoadScene(sceneBuildIndex: 1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene(sceneBuildIndex: 0);

    }

    

    public void GoToCredits()
    {
        SceneManager.LoadScene(sceneBuildIndex: 5);
    }

}
