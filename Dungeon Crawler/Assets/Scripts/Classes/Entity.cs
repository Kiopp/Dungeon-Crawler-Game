using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Represents an entity (player, enemy)
public abstract class Entity : MonoBehaviour, IBattleEntity
{
    public int Health { get; protected set; } //Current health of the entity
    public int Damage { get; protected set; } //The amount of damage an entity can deal

    //Attacks another entity
    public abstract void Attack(IBattleEntity opponent);

    //Inflicts damage to the entity
    public abstract void TakeDamage(int Damage);

    //Checks if the entity is dead
    public abstract bool Dead();
}
