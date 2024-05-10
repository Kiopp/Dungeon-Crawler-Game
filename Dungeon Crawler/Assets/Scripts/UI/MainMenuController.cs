using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelBuilderTest");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
