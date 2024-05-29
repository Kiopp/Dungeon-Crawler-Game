using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections;
using System.Reflection;

public class UIManagerTests
{
    private GameObject uiManagerObject;
    private UIManager uiManager;
    private Button[] buttons;
    private Text logText;

    [SetUp]
    public void Setup()
    {
        // Create a new GameObject and add the UIManager component
        uiManagerObject = new GameObject();
        uiManager = uiManagerObject.AddComponent<UIManager>();

        // Create and assign buttons and logText
        buttons = new Button[3];
        for (int i = 0; i < buttons.Length; i++)
        {
            GameObject buttonObject = new GameObject();
            buttons[i] = buttonObject.AddComponent<Button>();
            buttonObject.AddComponent<CanvasRenderer>();
            buttonObject.AddComponent<Image>();

            GameObject textObject = new GameObject();
            Text buttonText = textObject.AddComponent<Text>();
            buttonText.text = $"Button {i}";
            textObject.transform.SetParent(buttonObject.transform);
        }

        // Use reflection to set private fields
        var buttonsField = typeof(UIManager).GetField("buttons", BindingFlags.NonPublic | BindingFlags.Instance);
        buttonsField.SetValue(uiManager, buttons);

        GameObject logTextObject = new GameObject();
        logText = logTextObject.AddComponent<Text>();
        var logTextField = typeof(UIManager).GetField("LogText", BindingFlags.NonPublic | BindingFlags.Instance);
        logTextField.SetValue(uiManager, logText);

        // Manually call Start to simulate Unity lifecycle
        uiManagerObject.AddComponent<StartInvoker>().InvokeStart(uiManager);
    }

    [TearDown]
    public void Teardown()
    {
        Object.DestroyImmediate(uiManagerObject);
        foreach (var button in buttons)
        {
            Object.DestroyImmediate(button.gameObject);
        }
        Object.DestroyImmediate(logText.gameObject);
    }

    [UnityTest]
    public IEnumerator ButtonClick_TriggersOnAttackEvent()
    {
        bool eventTriggered = false;
        uiManager.OnAttack += () => eventTriggered = true;

        buttons[0].onClick.Invoke();

        yield return null;

        Assert.IsTrue(eventTriggered);
    }

    [Test]
    public void ChangeButtonText_UpdatesButtonText()
    {
        uiManager.ChangeButtonText(1, "New Text");

        Text buttonText = buttons[1].GetComponentInChildren<Text>();
        Assert.AreEqual("New Text", buttonText.text);
    }

    [Test]
    public void SetLogText_UpdatesLogText()
    {
        uiManager.SetLogText("Battle Started");

        Assert.AreEqual("Battle Started", logText.text);
    }

    [Test]
    public void SetAttackButtonText_UpdatesButtonText()
    {
        uiManager.SetAttackButtonText("Sword");

        Text buttonText = buttons[0].GetComponentInChildren<Text>();
        Assert.AreEqual("Attack with Sword", buttonText.text);
    }

    [UnityTest]
    public IEnumerator OnBattleStart_SetsLogText()
    {
        uiManager.OnBattleStart();

        yield return null;

        Assert.AreEqual("Enemy Encountered!", logText.text);
    }

    [UnityTest]
    public IEnumerator OnBattleEnd_SetsLogText()
    {
        uiManager.OnBattleEnd();

        yield return null;

        Assert.AreEqual("Battle Ended", logText.text);
    }
}

// Helper component to invoke Start manually
public class StartInvoker : MonoBehaviour
{
    public void InvokeStart(MonoBehaviour target)
    {
        target.Invoke("Start", 0);
    }
}
