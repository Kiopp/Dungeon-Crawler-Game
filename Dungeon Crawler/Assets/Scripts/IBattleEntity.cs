using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface for enteties involved in battles
public interface IBattleEntity
{
    int StartingHealth { get; } //Starting health of the entity
    int AttackDamage { get; } //The amount of damage an entity can deal
    float DodgeProbability { get; } //The dodge probability of an entity
    int CurrentHealth { get; } //Current health of the entity
    void Attack(IBattleEntity opponent); //Attacks another entity
    void TakeDamage(int Damage); //Inflicts damage to the entity
    bool Dead(); //Checks if the entity is dead
}
