using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Array dice;
    public float health;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update() {
        
    }

    public void TakeDamage(int damageAmount) {
        health -= damageAmount;
        if(health <= 0) {
            Destroy(gameObject);
        }
    }
}
