using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void isStartPressed()
    {
        SceneManager.LoadScene("DifficultyScene");
    }
    public void isQuitPressed()
    {
        Application.Quit();
    }
}
