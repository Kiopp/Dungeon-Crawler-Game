using UnityEngine;

//Inherits from the entity superclass 
public class Player : Entity
{
    //Creates a player with fixed health and damage
    public Player()
    {
        Health = 100;
        Damage = 10;
    }

    //Deals damage to enemies
    public void Attack(Enemy enemy)
    {
        enemy.TakeDamage(Damage);
    }

    //Player takes damage
    public override void TakeDamage(int Damage)
    {
        if (Random.Range(0, 5) == 0)
        {
            Health -= Damage;
            Dead();
        }
    }

    //Checks if the player is dead, returns true if the player is dead
    public override bool Dead()
    {
        if (Health <= 0)
        {
            Debug.Log("Player is Dead");
            return true;
        }

        return false;
    }

}
