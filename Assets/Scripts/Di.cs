using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Di : MonoBehaviour {

    private Player playerScript;

    public TMP_Text diNumberText;
    public int value;
    
    private float scale;
    private float newScale;
    private float newScaleEnemy;

    public bool isSelected;
    public bool isEnemy;
    public int? index;
    
    public Sprite[] spriteArray;
    public SpriteRenderer spriteRenderer;
    
    public virtual void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        isSelected = false;
        value = Random.Range(1, 7);

        scale = 0.13f;
        newScale = 0.05f;
        newScaleEnemy = 0.1f;

        spriteRenderer.sprite = spriteArray[value - 1]; 
        
        if(GameObject.FindGameObjectWithTag("Player") != null) {
            playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        if(isEnemy) {
            transform.localScale = new Vector3(newScaleEnemy + scale, newScaleEnemy + scale, 0);
        } else if (isEnemy == false) {
            transform.localScale = new Vector3(scale, scale, 0);

        }

        RollDi();
    }

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
                ResetScale();
            }
        }
    }
    
    void OnMouseDown()
    {
        if(!isEnemy && index != null) {
            isSelected = !isSelected;

            int newIndex = (int)index;
            playerScript.HandleSelectDi(newIndex);
        }
    }
    
    void RollDi() {
        diNumberText.text = value.ToString();
    }

    public void ResetScale() {
        transform.localScale -= new Vector3(newScale, newScale, 0);
    }
}