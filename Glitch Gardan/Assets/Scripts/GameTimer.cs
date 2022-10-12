using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float levelSeconds = 10;
    private Slider slider;
    private AudioSource audioSource;
    private bool isEndofLevel = false;
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        audioSource = GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = 1 - (Time.timeSinceLevelLoad / levelSeconds);
        bool isTimeUp = (Time.timeSinceLevelLoad >= levelSeconds);
        if (isTimeUp && !isEndofLevel)
        {
            audioSource.Play();
            Invoke("LoadNextLevel", audioSource.clip.length);
            isEndofLevel = true;
        }
    }

    void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
    
}
