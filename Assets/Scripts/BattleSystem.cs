using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum BattleState {
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST
}

public class BattleSystem : MonoBehaviour {

    private Player playerScript;
    public BattleState state;

    Player playerUnit;
    Enemy enemyUnit;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerSpawn;
    public Transform enemySpawn;

    public int damage;

    public int attackingDi;
    public int defendingDi;


    public TMP_Text enemyText;
    public TMP_Text playerText;

    private void Start() {
        //• spawn the dice
        //• display the player dice value
        //• wait for player choice
        //• display the enemy dice value
        //• calculate and display damage
        //• reset for next round
        state = BattleState.START;
        SetupBattle();
    
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        damage = 0;

        CalculateDamage(attackingDi, defendingDi);
        
        if (playerScript != null) {
            playerScript.TakeDamage(damage);
        }
    }

    // private void Update() {
    // }

    void SetupBattle() {
        GameObject playerGO = Instantiate(playerPrefab, playerSpawn);
        playerUnit = playerGO.GetComponent<Player>();
        GameObject enemyGO = Instantiate(enemyPrefab, enemySpawn);
        enemyUnit = enemyGO.GetComponent<Enemy>();

        playerText.text = playerUnit.name + " " + playerUnit.currentHealth.ToString();
        enemyText.text = enemyUnit.name + " " + enemyUnit.currentHealth.ToString();
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