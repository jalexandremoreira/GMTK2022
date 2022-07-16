using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Di
{
    public Di diToSpawn;

    public string name;
    public int diceNumber;
    public int damage;
    public int currentHealth;
    public int maxHealth;

    private Animator anim;

    public override void Start()
    {
        anim = GetComponent<Animator>();
        SpawnDice();
    }

    // private void Update() {
    // }

    public void TakeDamage(int damageAmount) {
        currentHealth -= damageAmount;
            print("currentHealth" + currentHealth);
            print("damageAmount" + damageAmount);

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
}
