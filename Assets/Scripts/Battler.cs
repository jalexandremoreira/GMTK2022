using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Battler : MonoBehaviour {

    public int damage;

    private Player playerScript;

    public int attackingDi;
    public int defendingDi;

    public TMP_Text valueText;

    private void Start() {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        damage = 0;
        //• spawn the dice
        //• display the player dice value
        //• wait for player choice
        //• display the enemy dice value
        //• calculate and display damage
        //• reset for next round

        CalculateDamage(attackingDi, defendingDi);
    }

    private void Update() {
        valueText.text = damage.ToString();
    }

    public void CalculateDamage(int attackDi, int defendDi) {
        if(attackDi == 1) {
            if(defendDi == 1) {
                damage = 0;
            } else if(defendDi == 2) {
                damage = 1;
            } else if(defendDi == 3) {
                damage = 0;
            } else if(defendDi == 4) {
                damage = 1;
            } else if(defendDi == 5) {
                damage = 0;
            } else if(defendDi == 6) {
                damage = 1;
            }
        } else if(attackDi == 2) {
            if(defendDi == 1) {
                damage = 2;
            } else if(defendDi == 2) {
                damage = 0;
            } else if(defendDi == 3) {
                damage = 0;
            } else if(defendDi == 4) {
                damage = 0;
            } else if(defendDi == 5) {
                damage = 0;
            } else if(defendDi == 6) {
                damage = 0;
            }
        } else if(attackDi == 3) {
            if(defendDi == 1) {
                damage = 2;
            } else if(defendDi == 2) {
                damage = 1;
            } else if(defendDi == 3) {
                damage = 0;
            } else if(defendDi == 4) {
                damage = 1;
            } else if(defendDi == 5) {
                damage = 0;
            } else if(defendDi == 6) {
                damage = 1;
            }
        } else if(attackDi == 4) {
            if(defendDi == 1) {
                damage = 4;
            } else if(defendDi == 2) {
                damage = 2;
            } else if(defendDi == 3) {
                damage = 2;
            } else if(defendDi == 4) {
                damage = 0;
            } else if(defendDi == 5) {
                damage = 0;
            } else if(defendDi == 6) {
                damage = 0;
            }
        } else if(attackDi == 5) {
            if(defendDi == 1) {
                damage = 4;
            } else if(defendDi == 2) {
                damage = 3;
            } else if(defendDi == 3) {
                damage = 2;
            } else if(defendDi == 4) {
                damage = 1;
            } else if(defendDi == 5) {
                damage = 0;
            } else if(defendDi == 6) {
                damage = 1;
            }
        } else if(attackDi == 6) {
            if(defendDi == 1) {
                damage = 6;
            } else if(defendDi == 2) {
                damage = 4;
            } else if(defendDi == 3) {
                damage = 4;
            } else if(defendDi == 4) {
                damage = 2;
            } else if(defendDi == 5) {
                damage = 2;
            } else if(defendDi == 6) {
                damage = 0;
            }
        }
    }
}