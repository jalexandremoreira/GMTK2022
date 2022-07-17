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
    }

    IEnumerator PlayerTurn() {
        if (playerUnit.hasChosenDi) {
            enemyUnit.CallSpawner();

            yield return new WaitForSeconds(.5f);

            CalculateDamage(playerUnit.selectedDi.value, enemyUnit.selectedDi.value);
            enemyUnit.TakeDamage(damage);

            // after we attack the enemy di stays on screen for a bit
            yield return new WaitForSeconds(1f);

            playerActionButtonText.text = "choose a di";
            playerActionButton.enabled = false;

            TurnCleanUp();
        } 
    }

    IEnumerator EnemyTurn() {
        if(playerUnit.hasChosenDi) {
            enemyUnit.CallSpawner();
            yield return new WaitForSeconds(0.5f);
            
            CalculateDamage(enemyUnit.selectedDi.value, playerUnit.selectedDi.value);
            print("enemy damage: " + damage);
            playerUnit.TakeDamage(damage);

            yield return new WaitForSeconds(1f);

            TurnCleanUp();
        }
    }

    void TurnCleanUp() {
        if (enemyUnit.currentHealth <= 0) {
            state = BattleState.WON;
            // EndBattle(won: true);
        } else if(playerUnit.currentHealth <= 0) {
            state = BattleState.LOST;
            // EndBattle(won: false);
        } else {
            if(state.Equals(BattleState.PLAYERTURN)) {
                state = BattleState.ENEMYTURN;
            } else if(state.Equals(BattleState.ENEMYTURN)){
                state = BattleState.PLAYERTURN;
            }
        }

        enemyUnit.CallDespawner();
        playerUnit.CallSpawner();
        playerUnit.hasChosenDi = false;
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

    public void OnChooseDi() {
        if(state == BattleState.PLAYERTURN) {
            StartCoroutine(PlayerTurn());
        } else if(state == BattleState.ENEMYTURN) {
            StartCoroutine(EnemyTurn());
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