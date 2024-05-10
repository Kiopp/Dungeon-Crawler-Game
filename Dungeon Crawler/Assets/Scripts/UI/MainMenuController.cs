using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Switch scene
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelBuilderTest");
    }

    // Close the application
    public void CloseGame()
    {
        Application.Quit();
    }
}
