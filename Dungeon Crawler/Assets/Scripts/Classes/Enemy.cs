using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Represents the enemy entity
public class Enemy : Entity
{
    [SerializeField] private int startHealth; //Enemy starting health (Visisble and editable in unity inspector)
    [SerializeField] private int enemyAttackDamage; //Enemy damage (Visisble and editable in unity inspector)
    [SerializeField] private float dodgeProbability; //Enemy dodge probability (Visisble and editable in unity inspector)
    [SerializeField] private ItemDropController itemDropper; //Item dropping controller (Visisble and editable in unity inspector)

    //Overrides the start method to initialize the enemy health and damage
    protected override void Start()
    {
        base.Start(); //Calls the base class start to initialize the currenthealth
        CurrentHealth = startHealth; //Sets the enemy health to the enemy starting health
        AttackDamage = enemyAttackDamage; //Sets the enemy damage
    }

    //Attacks the player
    public override void Attack(IBattleEntity player)
    {
        player.TakeDamage(AttackDamage); //Inflicts the enemy damage to the player
    }

    //Inflicts damage to the enemy
    public override void TakeDamage(int damage)
    {
        if (Random.Range(0F, 1F) >= dodgeProbability) //Has a chance to randomly dodge an attack
        {
            CurrentHealth -= damage; //Reduces the enemy health by the damage dealt
        }
    }

    //checks if the enemy has been killed
    public override bool Dead()
    {
        if (CurrentHealth <= 0)
        {
            itemDropper.DropItem(); // Drop an item
            return true; //Returns true if the enemy is dead
        }
        return false;
    }
}