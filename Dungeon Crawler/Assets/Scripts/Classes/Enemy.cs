using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    public Enemy(int HP, int DMG)
    {
        Health = HP;
        Damage = DMG;
    }

    public override void TakeDamage(int Damage)
    {
        if (Random.Range(0, 2) == 0)
        {
            Health -= Damage;
        }
    }

    public override void Dead()
    {
        if (Health <= 0)
        {
            Debug.Log("Enemy has been killed");
        }
    }
}
