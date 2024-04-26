using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTrigger : MonoBehaviour
{
    public BattleManager battleManager;
    [SerializeField] private GameObject enemy;

    private void OnTriggerEnter(Collider player)
    {
        Debug.Log("The mighty battle has begun!");
        battleManager.playerObject = player.gameObject;
        battleManager.StartBattle(player.gameObject.GetComponent<Player>(), enemy.gameObject.GetComponent<Enemy>());
    }
}
