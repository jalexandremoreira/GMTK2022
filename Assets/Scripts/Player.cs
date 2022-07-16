using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Di
{
    public Di diToSpawn;

    Di[] currentDice = { null, null, null, null };
    public Di selectedDi;

    public string name;
    public int diceNumber;
    public int currentHealth;
    public int maxHealth;

    public bool hasChosenDi;

    private Animator anim;


    public override void Start()
    {   
        hasChosenDi = false;
        anim = GetComponent<Animator>();
        CallSpawner();
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

    public void CallSpawner() {
        StartCoroutine(SpawnDice());
    }

    IEnumerator SpawnDice() {
        if(currentDice[0] != null) {
            hasChosenDi = false;

            for(int i = 0; i < diceNumber; i++) {
                if(currentDice[i] != null) {
                    Di di = currentDice[i].GetComponent<Di>();
                    currentDice[i] = null;
                    Destroy(di.gameObject);
                }
            }
        }
            
        for(int i = 0; i < diceNumber; i++) {
            float x = i == 0 ? 3 : 6.2f;
            float y = -2.5f;

            Di newDi = Instantiate(diToSpawn, new Vector3(x, y, 0), transform.rotation);
            newDi.index = i;

            currentDice[i] = newDi.GetComponent<Di>();
        }
        yield return new WaitForSeconds(.5f);
    }

    public void HandleSelectDi(int index) {
        print("index " + index);
        if(hasChosenDi) {
            print("has chosen di");
            if(selectedDi.index == index) {
                print("has chosen di");
                selectedDi = null;
            }

            for(int i = 0; i < diceNumber; i++) {
                Di di = currentDice[i].GetComponent<Di>();
                currentDice[i].index = null;
            }
        }

        hasChosenDi = true;
        selectedDi = currentDice[index].GetComponent<Di>();
    }    
}
