using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class GameInputTest
{
    // A UnityTest behaves like a coroutine in Play Mode.
    [UnityTest]
    public IEnumerator MoveOnce()
    {
        // Setup
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<GameInput>();

        player.PlayerObject = gameObject;

        // Gather pre-test information
        var startTime = Time.time;
        var moveDelay = player.GetMoveDelay();
        var startPosition = gameObject.transform.position;

        // Enable movement
        player.EnableMovement();

        // Move
        player.OnMoveStart();
        yield return new WaitForSeconds(moveDelay);
        player.OnMoveRelease();

        // Disable movement
        player.DisableMovement();

        // Gather post-test information
        var endPosition = gameObject.transform.position;

        // Confirm that timing is correct
        var elapsedTime = Time.time - startTime;
        Assert.That(elapsedTime, Is.GreaterThanOrEqualTo(moveDelay));

        // Give coroutine some time to finish
        yield return new WaitForSeconds(1);

        // Confirm that object moved correct amount
        var distanceMoved = Vector3.Distance(startPosition, endPosition);
        Assert.That(distanceMoved, Is.EqualTo(player.GetMoveDistance()).Within(1f));

        // Confirm the direction of movement
        var movedForward = Vector3.Dot(gameObject.transform.forward, endPosition - startPosition) > 0;
        Assert.IsTrue(movedForward);
    }

    [UnityTest]
    public IEnumerator MoveThreeTimes()
    {
        // Setup
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<GameInput>();

        player.PlayerObject = gameObject;

        // Gather pre-test information
        var startTime = Time.time;
        var moveDelay = player.GetMoveDelay() * 3;
        var startPosition = gameObject.transform.position;

        // Enable movement
        player.EnableMovement();

        // Move
        player.OnMoveStart();
        yield return new WaitForSeconds(moveDelay + 0.3f); // + 0.3f for extra delay.
        player.OnMoveRelease();

        // Disable movement
        player.DisableMovement();

        // Gather post-test information
        var endPosition = gameObject.transform.position;

        // Confirm that timing is correct
        var elapsedTime = Time.time - startTime;
        Assert.That(elapsedTime, Is.GreaterThanOrEqualTo(moveDelay));

        // Give coroutine some time to finish
        yield return new WaitForSeconds(1);

        // Confirm that object moved correct amount
        var distanceMoved = Vector3.Distance(startPosition, endPosition);
        Assert.That(distanceMoved, Is.EqualTo(player.GetMoveDistance() * 3).Within(1f));

        // Confirm the direction of movement
        var movedForward = Vector3.Dot(gameObject.transform.forward, endPosition - startPosition) > 0;
        Assert.IsTrue(movedForward);
    }

    [UnityTest]
    public IEnumerator RotateRightOnce()
    {
        // Setup
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<GameInput>();
        player.EnableSimulation(); // class no longer takes input from the PlayerInputActions
        player.SetRotationValue(1f); // simulate right rotation
        player.PlayerObject = gameObject;

        // Gather pre-test information
        var startTime = Time.time;
        var rotationDelay = player.GetRotateDelay();
        var startRotation = gameObject.transform.rotation;

        // Enable movement
        player.EnableMovement();

        // Move
        player.OnRotateStart();
        yield return new WaitForSeconds(rotationDelay);
        player.OnRotateRelease();

        // Disable movement
        player.DisableMovement();

        // Gather post-test information
        var endRotation = gameObject.transform.rotation;

        // Confirm that timing is correct
        var elapsedTime = Time.time - startTime;
        Assert.That(elapsedTime, Is.GreaterThanOrEqualTo(rotationDelay));

        // Give coroutine some time to finish
        yield return new WaitForSeconds(1);

        // Confirm any rotation
        Assert.AreNotEqual(startRotation, endRotation);

        // Confirm correct direction
        Assert.That(endRotation.eulerAngles.y, Is.EqualTo(startRotation.eulerAngles.y + 270).Within(10f));
    }

    [UnityTest]
    public IEnumerator RotateLeftOnce()
    {
        // Setup
        var gameObject = new GameObject();
        var player = gameObject.AddComponent<GameInput>();
        player.EnableSimulation(); // class no longer takes input from the PlayerInputActions
        player.SetRotationValue(-1f); // simulate left rotation
        player.PlayerObject = gameObject;

        // Gather pre-test information
        var startTime = Time.time;
        var rotationDelay = player.GetRotateDelay();
        var startRotation = gameObject.transform.rotation;

        // Enable movement
        player.EnableMovement();

        // Move
        player.OnRotateStart();
        yield return new WaitForSeconds(rotationDelay);
        player.OnRotateRelease();

        // Disable movement
        player.DisableMovement();

        // Gather post-test information
        var endRotation = gameObject.transform.rotation;

        // Confirm that timing is correct
        var elapsedTime = Time.time - startTime;
        Assert.That(elapsedTime, Is.GreaterThanOrEqualTo(rotationDelay));

        // Give coroutine some time to finish
        yield return new WaitForSeconds(1);

        // Confirm any rotation
        Assert.AreNotEqual(startRotation, endRotation);

        // Confirm correct direction
        Assert.That(endRotation.eulerAngles.y, Is.EqualTo(startRotation.eulerAngles.y + 90).Within(10f));
    }
}