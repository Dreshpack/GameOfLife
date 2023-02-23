using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void AutoModeButton()
    {
        SceneManager.UnloadScene(0);
        SceneManager.LoadScene(1);
    }

    public void ManualModeButton()
    {
        SceneManager.UnloadScene(0);
        SceneManager.LoadScene(2);
    }
    private void Start()
    {
        Debug.Log("1");
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            Debug.Log("2");
            //SceneManager.UnloadScene(1);
            //SceneManager.UnloadScene(2);
        }
        else
        {
            SceneManager.UnloadScene(SceneManager.GetActiveScene());
            SceneManager.LoadScene(0);
        }
    }
}

