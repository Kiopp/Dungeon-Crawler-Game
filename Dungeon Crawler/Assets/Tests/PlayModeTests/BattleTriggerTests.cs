using NUnit.Framework;
using UnityEngine;
using System.Reflection;
using UnityEngine.EventSystems;

[TestFixture]
public class BattleTriggerTests
{
    private GameObject triggerObject; 
    private BattleTrigger battleTrigger;
    private GameObject playerObject;
    private GameObject enemyObject;
    private Collider playerCollider;
    private MockUIBattleConnection uiBattleConnection;
    private MockBattleManager mockBattleManager;
    private MockCameraControl cameraControl;

    private class MockCameraControl : CameraControl
    {
        public new void Awake() { }

        public override void DisableMovement()
        {
            movementEnabled = false;
        }

        public override void EnableMovement()
        {
            movementEnabled = true;
        }

        public bool movementEnabled = true;
    }

    private class MockUIBattleConnection : UIBattleConnection
    {
        public bool checkedInUI = false;
        public bool checkedOutUI = false;

        public void MockStart(BattleManager battleManager)
        {
            this.battleManager = battleManager;
        }

        public override void checkInBattleManager(BattleManager battleManager)
        {
            checkedInUI = true;
        }

        public override void checkOutBattleManager()
        {
            checkedOutUI = true;
        }
    }

    private class MockBattleManager : BattleManager
    {
        public override void StartBattle(IBattleEntity player, IBattleEntity enemy)
        {
            Debug.Log("The battle has begun");
        }
    }

    [SetUp]
    public void SetUp()
    {
        // Create GameObjects
        triggerObject = new GameObject();
        battleTrigger = triggerObject.AddComponent<BattleTrigger>();
        playerObject = new GameObject();
        enemyObject = new GameObject();

        // Add necessary components
        uiBattleConnection = playerObject.AddComponent<MockUIBattleConnection>();
        cameraControl = playerObject.AddComponent<MockCameraControl>();

        playerObject.AddComponent<Player>();
        enemyObject.AddComponent<Enemy>();

        // Add a BoxCollider to playerObject
        playerObject.AddComponent<Rigidbody>();
        playerCollider = playerObject.AddComponent<BoxCollider>();
        playerCollider.isTrigger = true;

        // Add a BattleManager to battleTrigger
        battleTrigger.battleManager = new GameObject().AddComponent<MockBattleManager>();

        uiBattleConnection.MockStart(mockBattleManager);
        battleTrigger.enemyObject = enemyObject;
        GameObject triggerParent = new GameObject();
        triggerObject.transform.SetParent(triggerParent.transform);
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
        Assert.IsTrue(uiBattleConnection.checkedInUI);
        Assert.IsFalse(cameraControl.movementEnabled);
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
        Assert.IsTrue(uiBattleConnection.checkedOutUI);
        Assert.IsTrue(cameraControl.movementEnabled);
    }
}