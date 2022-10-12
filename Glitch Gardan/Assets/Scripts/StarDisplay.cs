using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour
{
    private Text starsDisplay;
    private int stars = 100;
    public enum Status { SUCCESS, FAILURE}

    // Start is called before the first frame update
    void Start()
    {
        starsDisplay = gameObject.GetComponent<Text>();
        UpdateScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddStarts(int amount)
    {
        stars += amount;
        UpdateScore();
    }

    public Status UseStarts(int amount)
    {
        if (stars >= amount) {
            stars -= amount;
            UpdateScore();
            return Status.SUCCESS;
        }
            return Status.FAILURE;
    }

    private void UpdateScore()
    {
        starsDisplay.text = stars.ToString();
    }
}
