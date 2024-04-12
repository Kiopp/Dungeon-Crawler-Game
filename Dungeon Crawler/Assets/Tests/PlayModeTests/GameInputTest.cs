using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

[TestFixture]
public class GameInputTest
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
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

        //Disable movement
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
        Assert.That(distanceMoved, Is.EqualTo(player.GetMoveDistance()).Within(0.5f));

        // Confirm the direction of movement
        var movedForward = Vector3.Dot(gameObject.transform.forward, endPosition - startPosition) > 0;
        Assert.IsTrue(movedForward);
    }
}
