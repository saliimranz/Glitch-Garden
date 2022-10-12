using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject DefenderPrefab;
    public static GameObject selectedDefender;

    private Button[] buttonArray;
    private Text costText;
    // Start is called before the first frame update
    void Start()
    {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        costText = GetComponentInChildren<Text>();
        if (!costText)
        {
            Debug.LogWarning("Cost not defined");
        }
        costText.text = DefenderPrefab.GetComponent<Defenders>().starCost.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        print(name + " pressed.");
        foreach(Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = DefenderPrefab;
    }
}
