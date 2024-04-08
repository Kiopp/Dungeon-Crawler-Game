using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BattleManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;

    private bool playerTurn = true;
    private bool battleOver = false;

    private PlayerInputActions inputActions;
    // Start is called before the first frame update
    void Start()
    {
        StartBattle();
        inputActions = new PlayerInputActions();
        inputActions.Player.Attack.performed += _ => OnAttack();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void StartBattle()
    {
        Debug.Log("Battle has started");
    }

    // Update is called once per frame
    void Update()
    {
        if (!battleOver && !playerTurn)
        {
            EnemyTurn();
        }
    }

    public void OnAttack()
    {
        if (!battleOver && playerTurn)
        {
            Debug.Log("Player attacks");
            player.Attack(enemy);
            if (player.Dead() == true)
            {
                battleOver = true;
            }
            else
            {
                playerTurn = false;
            }
        }
    }

    public void EnemyTurn()
    {
        Debug.Log("Enemy attacks");
        enemy.Attack(player);
        if (enemy.Dead == true)
        {
            battleOver = true;
        }
        else
        {
            playerTurn = true;
        }
    }
}
