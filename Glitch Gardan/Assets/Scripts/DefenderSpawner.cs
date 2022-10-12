using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public Camera myCamera;
    private GameObject parent;
    private StarDisplay starDisplay;
    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("Defenders");
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        if (!parent)
        {
            parent = new GameObject("Defenders");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Vector2 rawPos = WorldPointofMouseClick();
        Vector2 roundedPos = SnapToGrid(WorldPointofMouseClick());
        GameObject Defender = Button.selectedDefender;

        int defenderCost = Defender.GetComponent<Defenders>().starCost;
        if (starDisplay.UseStarts(defenderCost) == StarDisplay.Status.SUCCESS) {
            SpawnDefender(roundedPos, Defender);
        }
        else
        {
            Debug.Log("Insufficient stars to spawn");
        }
    }

    private void SpawnDefender(Vector2 roundedPos, GameObject Defender)
    {
        Quaternion zeroRot = Quaternion.identity;

        GameObject newDef = Instantiate(Defender, roundedPos, zeroRot) as GameObject;
        newDef.transform.parent = parent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawPos)
    {
        float newX = Mathf.RoundToInt(rawPos.x);
        float newY = Mathf.RoundToInt(rawPos.y);

        return new Vector2(newX, newY);
    }

    Vector2 WorldPointofMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 wierdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(wierdTriplet);

        return worldPos;
    }
}
