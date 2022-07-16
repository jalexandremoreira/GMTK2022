using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : Di
{
    public TMP_Text displayPlayerHealth;
    public Di diToSpawn;

    public int diceNumber;
    public int health;

    private Animator anim;

    public override void Start()
    {
        anim = GetComponent<Animator>();

        SpawnDice();
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

    public void SpawnDice() {
        for(int i = 0; i < diceNumber; i++) {
            float x = i == 0 ? 3 : 6.2f;
            float y = -2.5f;
            Instantiate(diToSpawn, new Vector3(x, y, 0), transform.rotation);

        }
    }
}
