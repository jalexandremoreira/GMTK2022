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

    public BattleState state;

    Player playerUnit;
    Enemy enemyUnit;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerSpawn;
    public Transform enemySpawn;

    public TMP_Text enemyText;
    public TMP_Text playerText;

    public int damage;

    public int attackingDi;
    public int defendingDi;

    private void Start() {
        state = BattleState.START;
        StartCoroutine(SetupBattle());

        damage = 0;

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
        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();    
    }

    public void Update() {
        if(playerText != null) {
            playerText.text = playerUnit.name + " " + playerUnit.currentHealth.ToString();
        }
        if(enemyText != null) {
            enemyText.text = enemyUnit.name + " " + enemyUnit.currentHealth.ToString();
        }
    }

    void PlayerTurn() {
        // choose a di
        playerText.text = "your turn";
        PlayerAction();
    }

    IEnumerator PlayerAction() {
        if (playerUnit.hasChosenDi) {
            CalculateDamage(playerUnit.diValue, enemyUnit.diValue);
            enemyUnit.TakeDamage(damage);
        }

        state = BattleState.ENEMYTURN;
        yield return new WaitForSeconds(2f);
        // EnemyTurn();
    }

    public void OnChooseDi() {
        StartCoroutine(PlayerAction());
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