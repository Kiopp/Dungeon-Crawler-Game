using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface for enteties involved in battles
public interface IBattleEntity
{
    int startingHealth { get; } //Starting health of the entity
    int Damage { get; } //The amount of damage an entity can deal
    float Dodge { get; } //The dodge probability of an entity
    int currentHealth { get; } //Current health of the entity
    void Attack(IBattleEntity opponent); //Attacks another entity
    void TakeDamage(int Damage); //Inflicts damage to the entity
    bool Dead(); //Checks if the entity is dead
}
