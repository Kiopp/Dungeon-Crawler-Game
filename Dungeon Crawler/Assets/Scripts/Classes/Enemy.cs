using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inherits from the entitty superclass
public class Enemy : Entity
{
    //Creates an enemy with health and damage by choice
    public Enemy(int HP, int DMG)
    {
        Health = HP;
        Damage = DMG;
    }

    //Damages the enemy
    public override void TakeDamage(int Damage)
    {
        if (Random.Range(0, 2) == 0)
        {
            Health -= Damage;
            Dead();
        }
    }

    //checks if the enemy has been killed
    public override void Dead()
    {
        if (Health <= 0)
        {
            Debug.Log("Enemy has been killed");
        }
    }
}
