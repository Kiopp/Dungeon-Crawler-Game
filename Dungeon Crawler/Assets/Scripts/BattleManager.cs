using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using GameInputActions;
using PlasticPipe.PlasticProtocol.Messages;

//A battle manager responsible for managing battles between the player and enemies
public class BattleManager : MonoBehaviour
{
    public GameObject playerObject;
    private IBattleEntity Player; //The player entity in the battle
    private IBattleEntity Enemy; //The enemy entity in the battle

    private PlayerInputActions playerInputActions; //Handles the players input

    private bool PlayerIsAttacking = false;

    void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable(); //Enables player inputs

        playerInputActions.Player.Attack.started += ctx => OnPlayerAttack();
        playerInputActions.Player.Attack.canceled += ctx => StopPlayerAttack();
    }

    public void OnPlayerAttack()
    {
        PlayerIsAttacking = true;
    }

    public void StopPlayerAttack()
    {
        PlayerIsAttacking = false;
    }

    //Disables the player input when the script is disabled
    private void OnDisable()
    {
        playerInputActions.Disable(); //Disables player inputs
    }

    //Starts the battle between a player and an enemy
    public void StartBattle(IBattleEntity player, IBattleEntity enemy)
    {
        Player = player;
        Enemy = enemy;

        playerObject.GetComponent<CameraControl>().DisableMovement();

        Debug.Log("The battle has begun");
        StartCoroutine(BattleLoop()); //Starts the battle loop coroutine
    }

    //Turned based battle loop
    private IEnumerator BattleLoop()
    {
        while (!Player.Dead() && !Enemy.Dead()) //Continues the battle as long as both the player and the enemy is alive
        {
            //Player turn
            Debug.Log("Player turn");
            yield return new WaitUntil(() => PlayerIsAttacking); //Checks if the attack input is triggered
            Player.Attack(Enemy); //The player attacks the enemy

            //Checks if the enemy is dead after the player turn
            if (Enemy.Dead())
            {
                Debug.Log("Enemy is dead, Player wins!");
                EndBattle();
                break;
            }

            yield return new WaitForSeconds(1);

            //Enemy turn
            Debug.Log("Enemy turn");
            Enemy.Attack(Player); //Enemy attacks player

            //Checks if the player is dead after the enemy turn
            if (Player.Dead())
            {
                Debug.Log("Player is dead, Enemy wins!");
                EndBattle();
                break;
            }

            yield return null; //Yield control back to unity until next frame
        }
    }

    private void EndBattle()
    {
        playerObject.GetComponent<CameraControl>().EnableMovement();
    }

    public bool CheckBattleResult()
    {
        return Player.Dead() || Enemy.Dead();
    }
}