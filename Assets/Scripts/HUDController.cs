using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour {

    private Player playerScript;
    public TMP_Text buttonText;

    // public void Start() {
    //     buttonText.text = "choose di";

    //     if(GameObject.FindGameObjectWithTag("Player") != null) {
    //         playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    //     }
    // }

    // public void Update() {
    //     print("updating ");
    //     if(playerScript != null) {
    //         print("player bool " + playerScript.hasChosenDi);
    //         if(playerScript.hasChosenDi == true) {
    //             buttonText.text = "attack";
    //         } else {
    //             buttonText.text = "choose di";
    //         }
    //     }
    // }
}