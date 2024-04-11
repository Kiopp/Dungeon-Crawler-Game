using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface for enteties involved in battles
public interface IBattleEntity
{
    int Health { get; } //Current health of the entity
    int Damage { get; } //The amount of damage an entity can deal
    void Attack(IBattleEntity opponent); //Attacks another entity
    void TakeDamage(int Damage); //Inflicts damage to the entity
    bool Dead(); //Checks if the entity is dead
}
