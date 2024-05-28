using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBattleConnection : MonoBehaviour
{
    // Written by Jesper Wentzell and Joel Majava
    [SerializeField] private Player player;
    [SerializeField] private UIManager UI;
    protected BattleManager battleManager { get; set; }

    public virtual void checkInBattleManager(BattleManager battleManager)
    {
        this.battleManager = battleManager;
        this.battleManager.BattleRound.AddListener(OnBattleRound);
        this.battleManager.BattleStart.AddListener(OnBattleStart);
        this.battleManager.BattleEnded.AddListener(OnBattleEnded);
    }

    public virtual void checkOutBattleManager()
    {
        this.battleManager = null;
    }

    void Start()
    {
        UI.OnAttack += HandleAttack;
        player.NewWeaponEquipped += HandleNewWeapon;
        player.Healed += HandleHealing;
    }

    public void OnBattleStart()
    {
        UI.SetLogText("Battle Started!");
    }

    public void OnBattleRound(BattleRoundEventArgs e)
    {
        UI.SetLogText($"Player Health: {e.playerHealth}/{e.playerMaxHealth}\n" +
                  $"Player Damage Dealt: {e.playerDamageDealt}\n" +
                  $"Enemy Health: {e.enemyHealth}/{e.enemyMaxHealth}\n" +
                  $"Enemy Damage Dealt: {e.enemyDamageDealt}");
    }

    public void OnBattleEnded()
    {
        UI.SetLogText("Enemy has been slain!");
    }

    public void HandleAttack()
    {
        if (battleManager != null)
        {
            this.battleManager.OnPlayerAttack();
        }
    }

    public void HandleNewWeapon(string newWeapon)
    {
        UI.SetAttackButtonText(newWeapon);
        UI.SetLogText("Equipped new weapon: " + newWeapon);
        Debug.Log("Name of new weapon: " + newWeapon);
    }

    public void HandleHealing(double healingAmount)
    {
        UI.SetLogText("You healed: " + healingAmount);
    }
}
