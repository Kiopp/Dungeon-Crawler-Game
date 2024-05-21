using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private InventoryManager inventoryManager;
    //[SerializeField] private UIManager UI;
    private BattleManager battleManager { get; set; }

    public void checkInBattleManager(BattleManager battleManager)
    {
        this.battleManager = battleManager;
        this.battleManager.BattleRound.AddListener(OnBattleRound);
    }

    public void checkOutBattleManager()
    {
        this.battleManager = null;
    }

    public void OnBattleRound(BattleRoundEventArgs e)
    {
        // NOT YET IMPLEMENTED
        // Notify the UIManager to update stats from the battle
        // Need UIManager to complete
    }

    public void OnBattleEnded()
    {
        // NOT YET IMPLEMENTED
        // Notify the UIManager that the battle ended
        // Need UIManager to complete
    }

    public void UseItem(Item item)
    {
        Debug.Log("Trying to use item");
        if (item is Weapon weapon)
        {
            // Equip 
            player.EquipWeapon(weapon);

            // Notift BattleManager that the player wants to attack
            if (battleManager != null)
            {
                battleManager.OnPlayerAttack();
            }
        }
        else if (item is Consumable consumable)
        {
            // Use and consume
            consumable.UseItem(player);
            inventoryManager.Remove(consumable);
        }
    }
}
