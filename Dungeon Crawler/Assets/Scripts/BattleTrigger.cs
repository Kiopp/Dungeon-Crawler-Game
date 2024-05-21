using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public BattleManager battleManager;
    [SerializeField] private GameObject enemyObject;
    private GameObject playerObject;
    private PlayerUIController playerUIController;

    private void OnTriggerEnter(Collider player)
    {
        Debug.Log("The mighty battle has begun!");
        playerObject = player.gameObject; // Save playerObject
        playerUIController = player.GetComponent<PlayerUIController>(); // Save UI controller
        playerUIController.checkInBattleManager(battleManager);
        playerObject.GetComponent<CameraControl>().DisableMovement(); // Disable player movement
        battleManager.BattleTriggerCheckIn(this); // Check in to BattleManager
        battleManager.StartBattle(playerObject.GetComponent<Player>(), enemyObject.GetComponent<Enemy>()); // Start Battle
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
        playerUIController?.checkOutBattleManager();

        // Disable certain objects
        transform.parent.gameObject.SetActive(false); // Disable the BattleTriggers
        enemyObject.SetActive(false); // Disable Enemy object
    }
}
