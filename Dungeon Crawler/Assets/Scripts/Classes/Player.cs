using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
//Represents the player entity
public class Player : Entity
{
    //Creates a player with specified health and damage
    public Player(int health, int damage)
    {
        Health = health; //Sets player health
        Damage = damage; //Sets player damage
    }

    //Attacks an enemy
    public override void Attack(IBattleEntity enemy)
    {
        enemy.TakeDamage(Damage); //Inflicts the player damage to an enemy
    }

    //Inflicts damage to the player
    public override void TakeDamage(int Damage)
    {
        if (Random.Range(0, 10) != 0) //Has a chance to randomly dodge an attack
        {
            Health -= Damage; //Reduces the player health by the damage dealt
        }
    }

    //Checks if the player is dead
    public override bool Dead()
    {
        return Health <= 0; //Returns true if the player is dead
    }

}
