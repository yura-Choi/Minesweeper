using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
    
	void Update () {
        string status_BGM = PlayerPrefs.GetString("bgm");

        // If status_BGM is true, the AudioListener will be listening.
        switch (status_BGM.ToLower()) {
        case "false":
            AudioListener.pause = true;
            break;
        case "true": default:
            AudioListener.pause = false;
            break;
        }
	}
}
