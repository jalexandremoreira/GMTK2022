using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Di : MonoBehaviour {

    public TMP_Text diNumberText;
    public int value;
    
    private float newScale;
    private float newScaleEnemy;

    public bool isSelected;
    public bool isEnemy;
    
    public virtual void Start() {
        value = Random.Range(1, 7);
        newScale = 0.15f;
        newScaleEnemy = 0.2f;
        
        if(isEnemy) {
            transform.localScale += new Vector3(newScaleEnemy, newScaleEnemy, 0);
        }

        RollDi();
    }

    // private void Update() {
    // }

    void OnMouseEnter()
    {
        if(!isEnemy) {
            if(!isSelected) {
                transform.localScale += new Vector3(newScale, newScale, 0);
            }
        }
    }
    
    void OnMouseExit()
    {
        if(!isEnemy) {
            if(!isSelected) {
                transform.localScale -= new Vector3(newScale, newScale, 0);
            }
        }
    }
    
    void OnMouseDown()
    {
        if(!isEnemy) {
            isSelected = !isSelected;
        }
    }
    
    void RollDi() {
        diNumberText.text = value.ToString();
    }
}