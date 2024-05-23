using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Represents the player entity
public class Player : Entity
{
    [SerializeField] public double startHealth; //Player starting health (Visisble and editable in unity inspector)
    [SerializeField] private double playerAttackDamage; //Player damage (Visisble and editable in unity inspector)
    [SerializeField] private float dodgeProbability; //Player dodge probability (Visisble and editable in unity inspector)
    private Weapon currentWeapon; // Weapon used for damage calculations

    public delegate void NewWeaponEquippedEventHandler(string newWeapon);

    public event NewWeaponEquippedEventHandler NewWeaponEquipped;

    //Overrides the start method to initialize the player health and damage
    protected override void Start()
    {
        base.Start(); //Calls the base class start to initialize the currenthealth
        CurrentHealth = startHealth; //Sets the enemy health to the player starting health
        AttackDamage = playerAttackDamage; //Sets the player damage
    }

    // Equip a weapon
    public void EquipWeapon(Weapon newWeapon)
    {
        currentWeapon = newWeapon;
        NewWeaponEquipped?.Invoke(newWeapon.name);
        Debug.Log("Equipping new weapon");
    }

    //Attacks an enemy
    public override double Attack(IBattleEntity enemy)
    {
        double totalDamage = playerAttackDamage;

        if (currentWeapon == null)
        {
            if (enemy.TakeDamage(totalDamage))
            {
                return totalDamage;
            }
            return 0;
        }
        totalDamage += currentWeapon.dmgDealt();

        //Inflicts the player damage to an enemy
        if (enemy.TakeDamage(totalDamage))
        {
            return totalDamage;
        }

        return 0;
    }

    //Inflicts damage to the player
    public override bool TakeDamage(double damage)
    {
        if (Random.Range(0F, 1F) >= dodgeProbability) //Has a chance to randomly dodge an attack
        {
            CurrentHealth -= damage; //Reduces the player health by the damage dealt
            return true;
        }
        return false;
    }

    // Heal the player
    public override void Heal(double healAmount)
    {
        // Heal
        CurrentHealth += healAmount;

        // Prevent having more than max health
        if (CurrentHealth > StartingHealth)
        {
            CurrentHealth = StartingHealth;
        }
    }

    //Checks if the player is dead
    public override bool Dead()
    {
        return CurrentHealth <= 0; //Returns true if the player is dead
    }
}
