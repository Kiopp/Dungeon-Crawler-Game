using UnityEngine;

public class Player : Entity
{
    public Player()
    {
        Health = 100;
        Damage = 10;
    }

    public override void TakeDamage(int Damage)
    {
        Health -= Damage;
    }

    public override void Dead()
    {
        if (Health <= 0)
        {
            Debug.Log("Player is Dead");
        }
    }

}
