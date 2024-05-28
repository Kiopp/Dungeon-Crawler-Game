using NUnit.Framework;
using UnityEngine;
using System.Reflection;

[TestFixture]
public class BattleTriggerTests
{
    private BattleTrigger battleTrigger;
    private GameObject playerObject;
    private GameObject enemyObject;
    private Collider playerCollider;
    private UIBattleConnection uiBattleConnection;
    private GameInputMock gameInputMock;
    private BattleManager battleManager;
    private CameraControl cameraControl;

    // Define a mock class for GameInput
    private class GameInputMock : GameInput
    {
        public void EnableMovement() { }
        public void DisableMovement() { }
    }

    [SetUp]
    public void SetUp()
    {
        // Create GameObjects
        battleTrigger = new GameObject().AddComponent<BattleTrigger>();
        playerObject = new GameObject();
        enemyObject = new GameObject();

        // Add necessary components
        uiBattleConnection = playerObject.AddComponent<UIBattleConnection>();
        cameraControl = playerObject.AddComponent<CameraControl>();

        // Add a BoxCollider to playerObject
        playerCollider = playerObject.AddComponent<BoxCollider>();

        // Add a BattleManager to battleTrigger
        battleTrigger.battleManager = new GameObject().AddComponent<BattleManager>();

        // Set up GameInputMock and assign it to cameraControl
        gameInputMock = new GameObject().AddComponent<GameInputMock>();
        FieldInfo field = typeof(CameraControl).GetField("gameInput", BindingFlags.NonPublic | BindingFlags.Instance);
        field.SetValue(cameraControl, gameInputMock);

        // Invoke Awake method of BattleTrigger
        MethodInfo awakeMethod = typeof(BattleTrigger).GetMethod("Awake", BindingFlags.NonPublic | BindingFlags.Instance);
        awakeMethod.Invoke(battleTrigger, null);
    }


    [TearDown]
    public void TearDown()
    {
        // Clean up GameObjects or components created during setup
        GameObject.Destroy(battleTrigger.gameObject);
        GameObject.Destroy(playerObject);
        GameObject.Destroy(enemyObject);
    }

    [Test]
    public void BattleHasStarted()
    {
        // Act
        battleTrigger.OnTriggerEnter(playerCollider);

        // Assert
        Assert.IsTrue(battleTrigger.GetBattleIsOn(), "Battle should be on after trigger is entered.");
        Assert.IsNotNull(battleTrigger.battleManager, "Battle manager should be assigned.");
        // Add more assertions as needed
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
        Assert.IsNull(battleTrigger.battleManager, "Battle manager should be null after ending the battle.");
        // Add more assertions as needed
    }
}