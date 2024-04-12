using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
//Represents the player entity
public class Player : Entity
{
    [SerializeField] private int startHealth; //Player starting health (Visisble and editable in unity inspector)
    [SerializeField] private int attackDamage; //Player damage (Visisble and editable in unity inspector)
    [SerializeField] private float dodgeProbability; //Player dodge probability (Visisble and editable in unity inspector)

    //Overrides the start method to initialize the enemy health and damage
    protected override void Start()
    {
        base.Start(); //Calls the base class start to initialize the currenthealth
        Health = startHealth; //Sets the enemy starting health
        Damage = attackDamage; //Sets the enemy damage
    }

    //Attacks an enemy
    public override void Attack(IBattleEntity enemy)
    {
        enemy.TakeDamage(Damage); //Inflicts the player damage to an enemy
    }

    //Inflicts damage to the player
    public override void TakeDamage(int Damage)
    {
        if (Random.Range(0F, 1F) >= dodgeProbability) //Has a chance to randomly dodge an attack
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
