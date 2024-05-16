using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents the player entity
public class Player : Entity
{
    [SerializeField] private int startHealth;      // Player starting health (Visible and editable in Unity Inspector)
    [SerializeField] private int attackDamage;     // Player damage (Visible and editable in Unity Inspector)
    [SerializeField] private float dodgeProbability;  // Player dodge probability (Visible and editable in Unity Inspector)

    // Overrides the Start method to initialize the player health and damage
    protected override void Start()
    {
        base.Start();  // Calls the base class start to initialize the current health
        currentHealth = startHealth;  // Sets the enemy health to the player starting health
        Damage = attackDamage;  // Sets the player damage
    }

    // Attacks an enemy
    public override void Attack(IBattleEntity enemy)
    {
        enemy.TakeDamage(Damage);  // Inflicts the player damage to an enemy
    }

    // Inflicts damage to the player
    public override void TakeDamage(int Damage)
    {
        if (Random.Range(0F, 1F) >= dodgeProbability)  // Has a chance to randomly dodge an attack
        {
            currentHealth -= Damage;  // Reduces the player health by the damage dealt
        }
    }

    // Checks if the player is dead
    public override bool Dead()
    {
        return currentHealth <= 0;  // Returns true if the player is dead
    }
}