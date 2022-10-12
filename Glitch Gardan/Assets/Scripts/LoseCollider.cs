using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager levelManager;
    int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        i++;
        if (i >= 3) { levelManager.LoadLevel("03b Lose"); }
    }
}
