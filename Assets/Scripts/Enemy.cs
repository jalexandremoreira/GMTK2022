using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Di
{
    public Di diToSpawn;
    public Di selectedDi;

    public string name;
    public int diValue;
    public int currentHealth;
    public int maxHealth;

    public override void Start() {
        transform.localScale += new Vector3(-0.016f, -0.016f, 0);
    }
    
    public void TakeDamage(int damageAmount) {
        currentHealth -= damageAmount;
        if(currentHealth <= 0) {
            print("you killed an enemy");
            Destroy(gameObject);
        }
    }

    public void CallSpawner() {
        StartCoroutine(SpawnDi());
    }

    IEnumerator SpawnDi() {
        if(selectedDi != null) {
            Destroy(selectedDi.gameObject);
            
            yield return new WaitForSeconds(1.5f);
        }


        Di diGO = Instantiate(diToSpawn, new Vector3(4.6f, 0.8f, 0), transform.rotation);
        selectedDi = diGO.GetComponent<Di>();
        selectedDi.isEnemy = true;
        
        yield return new WaitForSeconds(0.5f);
        
        if(selectedDi != null) {
            diValue = selectedDi.value;
        }
    }
    
    public void CallDespawner() {
        StartCoroutine(DespawnDi());
    }

    IEnumerator DespawnDi() {
        if(selectedDi != null) {
            Destroy(selectedDi.gameObject);
            yield return new WaitForSeconds(1.5f);
        }
    }

    public void Animator(bool isAttacking) {
        if(isAttacking == true) {
            transform.localScale += new Vector3(0.08f, 0.08f, 0);
        } else if (isAttacking == false) {
            transform.localScale += new Vector3(-0.016f, -0.016f, 0);
        }
    }
}
