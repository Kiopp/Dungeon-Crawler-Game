using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class BattleTriggerTests
{
    private BattleTrigger battleTrigger;
    private GameObject playerObject;
    private GameObject enemyObject;
    private Collider playerCollider;

    [SetUp]
    public void SetUp()
    {
        battleTrigger = new GameObject().AddComponent<BattleTrigger>();
        playerObject = new GameObject();
        enemyObject = new GameObject();

        // Add necessary components and mock their behaviors
        var uiConnection = playerObject.AddComponent<UIBattleConnection>(); // Assuming UIBattleConnection is a MonoBehaviour
        var cameraControl = playerObject.AddComponent<CameraControl>(); // Assuming CameraControl is a MonoBehaviour

        enemyObject.AddComponent<BoxCollider>();
        battleTrigger.battleManager = new GameObject().AddComponent<BattleManager>(); // Assuming BattleManager is a MonoBehaviour
        //battleTrigger.enemyObject = enemyObject;

        playerCollider = playerObject.GetComponent<BoxCollider>();
    }

    [Test]
    public void BattleHasStarted()
    {
        // Act
        battleTrigger.OnTriggerEnter(playerCollider);

        // Assert
        Assert.IsTrue(battleTrigger.GetBattleIsOn(), "Battle should be on after trigger is entered.");
    }

    [Test]
    public void BattleHasEnded()
    {
        // Setup - ensuring the battle is set to on initially
        battleTrigger.OnTriggerEnter(playerCollider);

        // Act
        battleTrigger.BattleEnded();

        // Assert
        Assert.IsFalse(battleTrigger.GetBattleIsOn(), "Battle should be off after it has ended.");
    }
}