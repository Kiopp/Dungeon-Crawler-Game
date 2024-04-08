using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    //Attributes for the enteties
    public int Health;
    public int Damage;

    //A method for different entities to take damage
    public abstract void TakeDamage(int Damage);

    //A method to see if enteties have been defeated/killed
    public abstract bool Dead();
}
