using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour
{
    private StarDisplay stardisplay;
    public int starCost = 100;

    private void Start()
    {
        stardisplay = GameObject.FindObjectOfType<StarDisplay>();
    }
    public void AddStarts(int amount)
    {
        stardisplay.AddStarts(amount);
    }
}
