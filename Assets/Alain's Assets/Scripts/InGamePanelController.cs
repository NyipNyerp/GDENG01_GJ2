using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGamePanelController : MonoBehaviour
{
    [SerializeField] private GameObject GamePanel;

    public void isPausePressed()
    {
        GamePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void isResumePressed()
    {
        GamePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void isMainMenuPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void isRestartPressed()
    {
        SceneManager.LoadScene("MainGame");
    }
    public void isQuitPressed()
    {
        Application.Quit();
    }
}
