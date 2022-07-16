using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Di
{
    public Di diToSpawn;
    Di selectedDi;

    public string name;
    public int diValue;
    public int currentHealth;
    public int maxHealth;

    private Animator anim;

    public override void Start()
    {
        anim = GetComponent<Animator>();

        StartCoroutine(SpawnDi());
    }
    
    public void TakeDamage(int damageAmount) {
        currentHealth -= damageAmount;
            print("currentHealth" + currentHealth);
            print("damageAmount" + damageAmount);

        if(currentHealth <= 0) {
            print("you killed an enemy");
            Destroy(gameObject);
        }
    }

    IEnumerator SpawnDi() {
        Di diGO = Instantiate(diToSpawn, new Vector3(4.6f, 1.6f, 0), transform.rotation);
        selectedDi = diGO.GetComponent<Di>();
        selectedDi.isEnemy = true;
        
        yield return new WaitForSeconds(0.5f);
        
        if(selectedDi != null) {
            diValue = selectedDi.value;
        }
    }
}
