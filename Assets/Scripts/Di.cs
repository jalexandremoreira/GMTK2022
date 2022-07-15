using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Di : MonoBehaviour {

    public TextMeshProUGUI valueText;
    public int value;

    private void Start() {
        value = Random.Range(1, 7);
    }

    private void Update() {
        valueText.text = value.ToString();
    }
}