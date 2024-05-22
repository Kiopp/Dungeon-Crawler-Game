using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class EntityTest
{
    // Declare attacking and targeted entities for the test
    private IBattleEntity targetEntity;
    private IBattleEntity targetEntityHighDodge;
    private IBattleEntity attackerEntity;

    // Creates mock attacking and targeted entities for each test
    [SetUp]
    public void Setup()
    {
        targetEntity = new MockBattleEntity();
        targetEntityHighDodge = new MockBattleEntityHighDodge();
        attackerEntity = new MockBattleEntity();
    }

    // Destroy mock attacking and targeted entities for each test
    [TearDown]
    public void Teardown()
    {
        GameObject.Destroy(targetEntity as MonoBehaviour);
        GameObject.Destroy(targetEntityHighDodge as MonoBehaviour);
        GameObject.Destroy(attackerEntity as MonoBehaviour);
    }

    // Test to see if the entity deals damage when attacking and takes damage when being attacked
    [Test]
    public void EntityAttack_EntityTakesDamage()
    {
        // Act: Attacking entity attack target entity
        attackerEntity.Attack(targetEntity);

        // Assert: Check if the target entity has taken damage
        Assert.AreEqual(targetEntity.StartingHealth - attackerEntity.AttackDamage, targetEntity.CurrentHealth, "Target entity should have taken damage");
    }

    [Test]
    public void DodgeProbability()
    {
        // Act: Attacking entity attack target entity with high dodge probability and low dodge probability
        attackerEntity.Attack(targetEntityHighDodge);
        attackerEntity.Attack(targetEntity);

        // Assert: Check if the target entities has taken damage
        Assert.AreEqual(targetEntityHighDodge.CurrentHealth, targetEntityHighDodge.StartingHealth, "Target entity should not have taken damage");
        Assert.AreNotEqual(targetEntity.CurrentHealth, targetEntity.StartingHealth, "Target entity should have taken damage");
    }

    // Simulates a mock battle entity 
    public class MockBattleEntity : IBattleEntity
    {
        public double StartingHealth { get; } // Starting health of the battle entity
        public double AttackDamage { get; } // Attack damage of the battle entity
        public float DodgeProbability { get; private set; } // Dodge probability of the battle entity
        public double CurrentHealth { get; private set; } // Current health of the battle entity

        // Initializes battle entity attributes
        public MockBattleEntity(double health = 100, double damage = 10)
        {
            StartingHealth = health;
            AttackDamage = damage;
            DodgeProbability = 0F;
            CurrentHealth = health;
        }

        // Simulates an attack by the battle entity
        public double Attack(IBattleEntity opponent)
        {
            opponent.TakeDamage(AttackDamage);
            return AttackDamage;
        }

        // Simulates a battle entity taking damage
        public bool TakeDamage(double damage)
        {
            // Checks if the battle entity dodges the attack
            if (Random.Range(0F, 1F) >= DodgeProbability)
            {
                CurrentHealth -= damage;
                return true;
            }
            return false;
        }

        // Checks if the battle entity is dead
        public bool Dead()
        {
            return CurrentHealth <= 0;
        }
    }

    // Simulates a mock battle entity with high dodge probability
    public class MockBattleEntityHighDodge : IBattleEntity
    {
        public double StartingHealth { get; } // Starting health of the battle entity
        public double AttackDamage { get; } // Attack damage of the battle entity
        public float DodgeProbability { get; private set; } // Dodge probability of the battle entity
        public double CurrentHealth { get; private set; } // Current health of the battle entity

        // Initializes battle entity attributes
        public MockBattleEntityHighDodge(double health = 100, double damage = 10)
        {
            StartingHealth = health;
            AttackDamage = damage;
            DodgeProbability = 1F;
            CurrentHealth = health;
        }

        // Simulates an attack by the battle entity
        public double Attack(IBattleEntity opponent)
        {
            opponent.TakeDamage(AttackDamage);
            return AttackDamage;
        }

        // Simulates a battle entity taking damage
        public bool TakeDamage(double damage)
        {
            // Checks if the battle entity dodges the attack
            if (Random.Range(0F, 1F) >= DodgeProbability)
            {
                CurrentHealth -= damage;
                return true;
            }
            return false;
        }

        // Checks if the battle entity is dead
        public bool Dead()
        {
            return CurrentHealth <= 0;
        }
    }
}
