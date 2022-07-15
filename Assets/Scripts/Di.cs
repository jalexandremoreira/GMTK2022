using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Di : MonoBehaviour {

    public TMP_Text valueText;
    public int value;
    
    private Color startcolor;
    private float newScale;
    
    private void Start() {
        value = Random.Range(1, 7);
        newScale = 0.15f;
    }

    private void Update() {
        RollDi();
    }

    void OnMouseEnter()
    {
        print($"Mouse entered {this.name}");
        // float newScale = Mathf.Lerp(0.1f, 0, Time.deltaTime / 10);
        // print(newScale);
        transform.localScale += new Vector3(newScale, newScale, 0);
    }
    
    void OnMouseExit()
    {
        // float newScale = Mathf.Lerp(0, 0.1f, Time.deltaTime / 10);
        transform.localScale -= new Vector3(newScale, newScale, 0);
    }
    
    void OnMouseDown()
    {
        print($"selected {this.value} as attack");
    }
    
    void RollDi() {
        valueText.text = value.ToString();
    }
}