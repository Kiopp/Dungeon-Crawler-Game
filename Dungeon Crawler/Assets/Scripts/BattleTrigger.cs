using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public BattleManager battleManager;
    [SerializeField] private GameObject enemyObject;
    private GameObject playerObject;

    private void OnTriggerEnter(Collider player)
    {
        Debug.Log("The mighty battle has begun!");
        playerObject = player.gameObject; // Save playerObject
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

        enemyObject.transform.parent.gameObject.SetActive(false); // Remove defeated enemy
    }
}
