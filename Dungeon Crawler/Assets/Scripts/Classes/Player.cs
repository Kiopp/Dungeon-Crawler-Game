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
        if (Random.Range(0, 5) == 0)
        {
            Health -= Damage;
            Dead();
        }
    }

    public override void Dead()
    {
        if (Health <= 0)
        {
            Debug.Log("Player is Dead");
        }
    }

}
