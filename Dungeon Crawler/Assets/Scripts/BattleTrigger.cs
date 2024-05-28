using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public BattleManager battleManager;
    [SerializeField] private GameObject enemyObject;
    private GameObject playerObject;
    private UIBattleConnection UIConnection;
    private bool battleIsOn = false;

    public void OnTriggerEnter(Collider player)
    {
        Debug.Log("The mighty battle has begun!");
        playerObject = player.gameObject; // Save playerObject
        UIConnection = player.GetComponent<UIBattleConnection>(); // Save UI controller
        UIConnection.checkInBattleManager(battleManager); // Connect battle manager to UI
        playerObject.GetComponent<CameraControl>().DisableMovement(); // Disable player movement
        battleManager.BattleTriggerCheckIn(this); // Check in trigger to BattleManager
        battleManager.StartBattle(playerObject.GetComponent<Player>(), enemyObject.GetComponent<Enemy>()); // Start Battle

        battleIsOn = true;
    }

    /// <summary>
    /// Called by BattleManager to signify the end of the battle
    /// </summary>
    public void BattleEnded()
    {
        if (playerObject != null)
        {
            playerObject.GetComponent<CameraControl>().EnableMovement(); // Enable player movement
        }
        UIConnection?.checkOutBattleManager();

        // Disable certain objects
        transform.parent.gameObject.SetActive(false); // Disable the BattleTriggers
        enemyObject.SetActive(false); // Disable Enemy object

        battleIsOn = false;
    }

    public bool GetBattleIsOn()
    {
        return battleIsOn;
    }
}
