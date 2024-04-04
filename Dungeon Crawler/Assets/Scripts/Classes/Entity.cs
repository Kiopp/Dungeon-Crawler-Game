using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public int Health;
    public int Damage;

    public abstract void TakeDamage();

    public abstract void Dead();
}
