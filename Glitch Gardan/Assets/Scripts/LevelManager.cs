using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public float autoLoadNextLevelAfter;

    public void Start()
    {
        if (autoLoadNextLevelAfter <= 0)
        {
            Debug.Log("Auto Load Disabled.");
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
    }
    public void LoadLevel(string name)
    {
        Debug.Log("Load level is called for: " + name);
        Application.LoadLevel(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit the game ");
        Application.Quit();
    }
    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
