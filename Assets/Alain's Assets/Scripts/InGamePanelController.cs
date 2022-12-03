using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGamePanelController : MonoBehaviour
{
    [SerializeField] private GameObject GamePanel;
    bool mouseLock = true;

    void Update()
    {
        Debug.Log(mouseLock);
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (mouseLock)
            {
                mouseLock = !mouseLock;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                mouseLock = !mouseLock;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void isPausePressed()
    {
        mouseLock = false;
        Cursor.lockState = CursorLockMode.None;
        GamePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void isResumePressed()
    {
        mouseLock = true;
        Cursor.lockState = CursorLockMode.Locked;
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
