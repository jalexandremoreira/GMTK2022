using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Di
{
    public Di diToSpawn;

    public string name;
    public int diceNumber;
    public int diValue;
    public int currentHealth;
    public int maxHealth;

    public bool hasChosenDi;

    private Animator anim;


    public override void Start()
    {   
        hasChosenDi = false;
        anim = GetComponent<Animator>();
        SpawnDice();
    }

    // void Update() {
    // }

    public void TakeDamage(int damageAmount) {
        currentHealth -= damageAmount;
        if(currentHealth <= 0) {
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

    public void SetValues(int setDamage, bool setHasChosenDi) {
        diValue = setDamage;
        hasChosenDi = setHasChosenDi;
    }
}
