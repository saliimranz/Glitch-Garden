using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setStartVolume : MonoBehaviour
{
    private MusicManager musicManager;
    // Start is called before the first frame update
    void Start()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        if (musicManager) {
            float volume = PlayerPrefsManager.GetMasterVolume();
            musicManager.SetVolume(volume);
            Debug.Log("Find Music Manager" + musicManager);
        }
        else
        {
            Debug.LogWarning("No Music manager found in start scene.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
