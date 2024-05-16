using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

     // An array to hold references to the Button components
    public Button[] buttons;


    // Start is called before the first frame update
    void Start()
    {
        // Assign listeners to each button dynamically
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;  // Capture the index for use in the lambda
            buttons[i].onClick.AddListener(() => OnButtonClick(index));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to handle button clicks
    void OnButtonClick(int buttonIndex)
    {
        Debug.Log("Button " + buttonIndex + " clicked.");
        // Perform additional actions based on which button was clicked
        // For example, change the text of the clicked button
        // ChangeButtonText(buttonIndex, "Clicked!");
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
}
