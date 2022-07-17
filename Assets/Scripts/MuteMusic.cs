using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class MuteMusic : MonoBehaviour {
    public TMP_Text muteButtonText;

    public void Start() {
        muteButtonText.text = "mute music";
    }

    public void Update() {
        if (AudioListener.volume == 0) {
            muteButtonText.text = "unmute music";
        }
        else if (AudioListener.volume == 1) {
            muteButtonText.text = "mute music";
        }
    }

    public void MuteToggle() {
        if (AudioListener.volume == 0) {
            AudioListener.volume = 1;
        }
        else if (AudioListener.volume == 1) {
            AudioListener.volume = 0;
        }
    }
}