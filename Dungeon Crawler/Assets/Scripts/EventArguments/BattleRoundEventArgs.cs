using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleRoundEventArgs
{
    public double playerHealth { get; }
    public double playerMaxHealth { get; }
    public double playerDamageDealt { get; }
    public double enemyHealth { get; }
    public double enemyMaxHealth { get; }
    public double enemyDamageDealt { get; }

    public BattleRoundEventArgs(double playerHealth, double playerMaxHealth, double playerDamageDealt, double enemyHealth, double enemyMaxHealth, double enemyDamageDealt)
    {
        this.playerHealth = playerHealth;
        this.playerMaxHealth = playerMaxHealth;
        this.playerDamageDealt = playerDamageDealt;
        this.enemyHealth = enemyHealth;
        this.enemyMaxHealth = enemyMaxHealth;
        this.enemyDamageDealt = enemyDamageDealt;
    }
}
