using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class StartLevel : MonoBehaviour
{
    public GameObject Option_1;
    IEnumerator Start()
    {
        Option_1.SetActive(false);
        yield return new WaitForSeconds(27f);
        Option_1.SetActive(true);
    }
    public void nextLevelStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
