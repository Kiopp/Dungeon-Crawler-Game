using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Represents the enemy entity
public class Enemy : Entity
{
    //Creates an enemy with specified health and damage
    public Enemy(int health, int damage)
    {
        Health = health; //Sets enemy health
        Damage = damage; //Sets enemy damage
    }

    //Attacks the player
    public override void Attack(IBattleEntity player)
    {
        player.TakeDamage(Damage); //Inflicts the enemy damage to the player
    }

    //Inflicts damage to the enemy
    public override void TakeDamage(int Damage)
    {
        if (Random.Range(0, 15) != 0) //Has a chance to randomly dodge an attack
        {
            Health -= Damage; //Reduces the enemy health by the damage dealt
        }
    }

    //checks if the enemy has been killed
    public override bool Dead()
    {
        return Health <= 0; //Returns true if the enemy is dead
    }
}
