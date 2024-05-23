using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBattleConnection : MonoBehaviour
{
    // Written by Jesper Wentzell
    [SerializeField] private Player player;
    [SerializeField] private UIManager UI;
    private BattleManager battleManager { get; set; }

    public void checkInBattleManager(BattleManager battleManager)
    {
        this.battleManager = battleManager;
        this.battleManager.BattleRound.AddListener(OnBattleRound);
        this.battleManager.BattleStart.AddListener(OnBattleStart);
    }

    public void checkOutBattleManager()
    {
        this.battleManager = null;
    }

    void Start()
    {
        UI.OnAttack += HandleAttack;
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
        
    }

    public void HandleAttack() 
    {
        if(battleManager != null) 
        {
            this.battleManager.OnPlayerAttack();
        }
    }

    void Update() {

    }
}
