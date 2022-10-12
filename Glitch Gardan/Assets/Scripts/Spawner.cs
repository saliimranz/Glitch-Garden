using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] AttackerPrefabArray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject thisAttacker in AttackerPrefabArray)
        {
            if (isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
        
    }

    void Spawn(GameObject myGameObject)
    {
        GameObject myattacker = Instantiate(myGameObject) as GameObject;
        myattacker.transform.parent = transform;
        myattacker.transform.position = transform.position;
    }

    bool isTimeToSpawn(GameObject attackersGameObject)
    {
        Attackers attacker = attackersGameObject.GetComponent<Attackers>();

        float meanSpawnDelay = attacker.seenEverySecound;
        float spawnsPerSecond = 1 / meanSpawnDelay;

        if(Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn Rate capped by frame rate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5 ;

        return (Random.value < threshold);
    }
}
