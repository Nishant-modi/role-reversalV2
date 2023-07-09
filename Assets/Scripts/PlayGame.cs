using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("Intro");
    }
    public void restart()
    {
        //int index = SceneManager.GetActiveScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void playagain()
    {
        SceneManager.LoadScene(0);
    }
}
