using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print(PlayerPrefsManager.GetMasterVolume());
       // PlayerPrefsManager.SetMasterVolume(0.3f);
        print(PlayerPrefsManager.GetMasterVolume());

        print(PlayerPrefsManager.IsUnlockLevel(2));
        PlayerPrefsManager.UnlockLevel(2);
        print(PlayerPrefsManager.IsUnlockLevel(2));

        print(PlayerPrefsManager.GetDifficulty());
       // PlayerPrefsManager.SetDifficulty(0.2f);
        print(PlayerPrefsManager.GetDifficulty());
    }

}
