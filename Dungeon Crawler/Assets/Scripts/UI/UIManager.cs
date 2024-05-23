using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Define a delegate type for the event
    public delegate void ButtonClickedAction();

    // Define an event based on that delegate
    public event ButtonClickedAction OnAttack;

     // An array to hold references to the Button components
    public Button[] buttons;

    [SerializeField] private Text LogText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to handle button clicks
    void OnButtonClick(int buttonIndex)
    {
        Debug.Log("Button " + buttonIndex + " clicked.");
        // If attack button is pressed perform attack action if in battle.
        if (buttonIndex == 0)
        {
            // Raise the OnAttack event if Button 0 is clicked
            OnAttack?.Invoke();
        }
    }

    // Method to change the text of a specific button
    public void ChangeButtonText(int buttonIndex, string newText)
    {
        if (buttonIndex < 0 || buttonIndex >= buttons.Length)
        {
            Debug.LogError("Invalid button index.");
            return;
        }

        Text buttonText = buttons[buttonIndex].GetComponentInChildren<Text>();
        if (buttonText != null)
        {
            buttonText.text = newText;
        }
        else
        {
            Debug.LogError("No Text component found on button.");
        }
    }

    // Method to be called when a fight begins
    public void OnBattleStart() {
        SetLogText("Enemy Encountered!");
    }

    // Method to be called when a fight ends.
    public void OnBattleEnd() {
        SetLogText("Battle Ended");
    }

    // Method that sets the ingame log to a message.
    public void SetLogText (string message) {
        LogText.text = message;        
    }
}