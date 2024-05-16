using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Represents an entity (player, enemy)
public abstract class Entity : MonoBehaviour, IBattleEntity
{
    [SerializeField] public int StartingHealth { get; protected set; } //Starting health of the entity (Visible and editable in unity inspector)
    [SerializeField] public int AttackDamage { get; protected set; } //The amount of damage an entity can deal (Visible and editable in unity inspector)
    [SerializeField] public float DodgeProbability { get; protected set; } //The dodge probability of an entity (Visible and editable in unity inspector)

    public int CurrentHealth { get; protected set; } //Current health of the entity

    //Start is called before the first fram update
    protected virtual void Start()
    {
        CurrentHealth = StartingHealth; //Initialize the current health to the starting health
    }

    //Attacks another entity
    public abstract void Attack(IBattleEntity opponent);

    //Inflicts damage to the entity
    public abstract void TakeDamage(int damage);

    //Checks if the entity is dead
    public abstract bool Dead();
}
