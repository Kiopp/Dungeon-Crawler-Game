using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface for enteties involved in battles
public interface IBattleEntity
{
    double StartingHealth { get; } //Starting health of the entity
    double AttackDamage { get; } //The amount of damage an entity can deal
    float DodgeProbability { get; } //The dodge probability of an entity
    double CurrentHealth { get; } //Current health of the entity
    double Attack(IBattleEntity opponent); //Attacks another entity
    bool TakeDamage(double Damage); //Inflicts damage to the entity
    bool Dead(); //Checks if the entity is dead
}
