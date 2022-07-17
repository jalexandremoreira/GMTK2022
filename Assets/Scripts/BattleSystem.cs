using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState {
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST
}

public class BattleSystem : MonoBehaviour {

    public BattleState state;

    Player playerUnit;
    Enemy enemyUnit;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerSpawn;
    public Transform enemySpawn;

    public TMP_Text enemyText;
    public TMP_Text playerText;
    public TMP_Text playerActionButtonText;
    public UnityEngine.UI.Button playerActionButton;

    public int damage;

    public int attackingDi;
    public int defendingDi;

    private void Start() {
        state = BattleState.START;
        StartCoroutine(SetupBattle());

        damage = 0;

        playerActionButtonText.text = "choose a di";
        playerActionButton.enabled = false;
    }
    
    IEnumerator SetupBattle() {
        if(playerPrefab != null) {
            GameObject playerGO = Instantiate(playerPrefab, playerSpawn);
            playerUnit = playerGO.GetComponent<Player>();
        }
        if(enemyPrefab != null) {
            GameObject enemyGO = Instantiate(enemyPrefab, enemySpawn);
            enemyUnit = enemyGO.GetComponent<Enemy>();
        }
        yield return new WaitForSeconds(0.2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();    
    }

    IEnumerator PlayerAction() {
        if (playerUnit.hasChosenDi) {
            enemyUnit.CallSpawner();

            yield return new WaitForSeconds(.5f);
            print("diValue" + enemyUnit.selectedDi.value);

            CalculateDamage(playerUnit.selectedDi.value, enemyUnit.selectedDi.value);
            enemyUnit.TakeDamage(damage);
        } 

        // after we attack the enemy di stays on screen for a bit
        yield return new WaitForSeconds(1f);
        // EnemyTurn();

        playerActionButtonText.text = "choose a di";
        playerActionButton.enabled = false;

        if (enemyUnit.currentHealth <= 0) {
            state = BattleState.WON;
            // EndBattle();
        } else {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyAction());
        }
    }

    IEnumerator EnemyAction() {
        enemyUnit.CallDespawner();
        playerUnit.CallSpawner();

        if(playerUnit.hasChosenDi) {
            if(playerActionButtonText != null) {
                playerActionButtonText.text = "defend";
                playerActionButton.enabled = true;
            }

            enemyUnit.CallSpawner();
            yield return new WaitForSeconds(0.2f);
            
            CalculateDamage(enemyUnit.selectedDi.value, playerUnit.selectedDi.value);
            playerUnit.TakeDamage(damage);
        }
    }

    public void Update() {
        if(playerText != null) {
            playerText.text = playerUnit.name + " " + playerUnit.currentHealth.ToString();
        }
        if(enemyText != null) {
            enemyText.text = enemyUnit.name + " " + enemyUnit.currentHealth.ToString();
        }

        if(playerUnit.hasChosenDi == true) {
            string buttonText = state.Equals(BattleState.PLAYERTURN) ? "attack with number " : state.Equals(BattleState.ENEMYTURN) ? "defend with number " : "";

            playerActionButtonText.text = buttonText + playerUnit.selectedDi.value + " di";

            playerActionButton.enabled = true;
        } else if(playerUnit.hasChosenDi == false) { 
            playerActionButtonText.text = "choose a di";
            playerActionButton.enabled = false;
        }
    }

    void PlayerTurn() {
        // choose a di
        playerText.text = "your turn";
    }

    

    public void OnChooseDi() {
        if(state == BattleState.PLAYERTURN) {
            StartCoroutine(PlayerAction());
        } else if(state == BattleState.ENEMYTURN) {
            StartCoroutine(EnemyAction());
        }
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