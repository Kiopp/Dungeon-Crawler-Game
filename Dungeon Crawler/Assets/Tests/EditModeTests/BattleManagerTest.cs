using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class BattleManagerTests
{
    // Declare mock entites and BattleManager instance
    private IBattleEntity mockPlayer;
    private IBattleEntity mockEnemy;
    private BattleManager battleManager;

    // Simulates a mock battle entity 
    public class MockBattleEntity : IBattleEntity
    {
        public int startingHealth { get; } // Starting health of the battle entity
        public int Damage { get; } // Attack damage of the battle entity
        public float Dodge { get; set; } // Dodge probability of the battle entity
        public int currentHealth { get; private set; } // Current health of the battle entity

        // Initializes battle entity attributes
        public MockBattleEntity(int health = 100, int damage = 10)
        {
            startingHealth = health;
            Damage = damage;
            Dodge = 0F;
            currentHealth = health;
        }

        // Simulates an attack by the battle entity
        public void Attack(IBattleEntity opponent)
        {
            opponent.TakeDamage(Damage);
        }

        // Simulates a battle entity taking damage
        public void TakeDamage(int damage)
        {
            // Checks if the battle entity dodges the attack
            if (Random.Range(0F, 1F) >= Dodge)
            {
                currentHealth -= damage;
            }
        }

        // Checks if the battle entity is dead
        public bool Dead()
        {
            return currentHealth <= 0;
        }
    }

    // Creates mock entities and battle manager object for each test
    [SetUp]
    public void Setup()
    {
        mockPlayer = new MockBattleEntity();
        mockEnemy = new MockBattleEntity();
        battleManager = new GameObject().AddComponent<BattleManager>();
    }

    // Destroy mock entities and battle manager object after each test
    [TearDown]
    public void TearDown() 
    {
        GameObject.Destroy(mockPlayer as MonoBehaviour);
        GameObject.Destroy(mockEnemy as MonoBehaviour);
        GameObject.Destroy(battleManager.gameObject);
    }

    // Test to see if battle manager correctly identifies a player win
    [Test]
    public void StartBattle_PlayerWins()
    {
        // Arrange: Make the enemy entity dead
        mockEnemy.TakeDamage(mockEnemy.startingHealth);

        // Act: Start the battle
        battleManager.StartBattle(mockPlayer, mockEnemy);

        // Assert: Check if the battle result is a win for the player
        Assert.IsTrue(battleManager.CheckBattleResult());
    }

    [Test]
    public void StartBattle_EnemyWins()
    {
        // Arrange: Make the player entity dead
        mockPlayer.TakeDamage(mockPlayer.startingHealth);

        // Act: Start the battle
        battleManager.StartBattle(mockPlayer, mockEnemy);

        // Assert: Check if the battle result is a win for the enemy
        Assert.IsTrue(battleManager.CheckBattleResult());
    }

    // Test to simulate a battle where the player wins
    [Test]
    public void BattleLoop_PlayerWins()
    {
        // Arrange: Add a player attack counter to see how many times the player attacks 
        int playerAttackCounter = 0;

        // Act: Start the battle
        battleManager.StartBattle(mockPlayer, mockEnemy);

        // Simulate battle loop until enemy is defeated
        while (!mockPlayer.Dead() && !mockEnemy.Dead())
        {
            mockPlayer.Attack(mockEnemy); // Player attacks enemy

            playerAttackCounter++;

            // Checks if the player has defeated the enemy
            if (mockEnemy.Dead())
            {
                // Enemy is defeated, exit the loop
                break;
            }

            mockEnemy.Attack(mockPlayer); // Enemy attacks player
        }

        // Assert: Check if the player wins the battle and if the enemy has taken damage
        Assert.IsTrue(mockEnemy.Dead(), "Enemy should be dead");
        Assert.IsFalse(mockPlayer.Dead(), "Player should be alive");
        Assert.IsTrue(battleManager.CheckBattleResult(), "Player should win the battle");
        Assert.AreEqual(mockEnemy.startingHealth - mockPlayer.Damage * playerAttackCounter, mockEnemy.currentHealth, "Enemy should have taken damage");
    }

    [Test]
    public void BattleLoop_EnemyWins()
    {
        // Arrange: Add a enemy attack counter to see how many times the enemy attacks
        int enemyAttackCounter = 0;

        // Act: Start the battle
        battleManager.StartBattle(mockPlayer, mockEnemy);

        // Simulate battle loop until player is defeated
        while (!mockPlayer.Dead() && !mockEnemy.Dead())
        {
            mockEnemy.Attack(mockPlayer); // Enemy attacks player

            enemyAttackCounter++;

            // Checks if the enemy has defeated the player
            if (mockPlayer.Dead())
            {
                // Player is defeated, exit the loop
                break;
            }

            mockPlayer.Attack(mockEnemy); // Player attacks enemy
        }

        // Assert: Check if the enemy wins the battle and if the player has taken damage
        Assert.IsTrue(mockPlayer.Dead(), "Player should be dead");
        Assert.IsFalse(mockEnemy.Dead(), "Enemy should be alive");
        Assert.IsTrue(battleManager.CheckBattleResult(), "Enemy should  win the battle");
        Assert.AreEqual(mockPlayer.startingHealth - mockEnemy.Damage * enemyAttackCounter, mockPlayer.currentHealth, "Player should have taken damage");
    }

    [Test]
    public void StartBattle_BothEntitiesDead()
    {
        // Arrange: make both entities dead
        mockPlayer.TakeDamage(mockPlayer.startingHealth);
        mockEnemy.TakeDamage(mockEnemy.startingHealth);

        // Act: Start the battle
        battleManager.StartBattle(mockPlayer, mockEnemy);

        // Assert: Check if the battle does not end in a win
        Assert.IsFalse(battleManager.CheckBattleResult(), "The battle should not result in a win for either entity");
    }
}