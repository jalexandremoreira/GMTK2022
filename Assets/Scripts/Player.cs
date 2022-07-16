using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public TMP_Text displayPlayerHealth;
    public Array dice;
    public float health;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update() {
        displayPlayerHealth.text = health.ToString();
    }

    public void TakeDamage(int damageAmount) {
        health -= damageAmount;
            print("health" + health);
            print("damageAmount" + damageAmount);

        if(health <= 0) {
            print("you died");
            Destroy(gameObject);
        }
    }
}
