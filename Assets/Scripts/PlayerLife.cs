using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private PlayerMovement player;

    [SerializeField] private GameObject DiePanel;
    [SerializeField] private GameObject Life4;
    [SerializeField] private GameObject Life3;
    [SerializeField] private GameObject Life2;
    [SerializeField] private GameObject Life1;

    void Awake()
    {
        Debug.Log("Press E to pickup/drop objects");
        Debug.Log("Press F to toggle flashlight on/off");
    }


    void Update()
    {
        text.SetText("x " + player.lives);

        if (player.lives == 4)
        {
            Life4.SetActive(true);
        }
        else if (player.lives == 3)
        {
            Life4.SetActive(false);
            Life3.SetActive(true);
        }
        else if (player.lives == 2)
        {
            Life3.SetActive(false);
            Life2.SetActive(true);
        }
        else if (player.lives == 1)
        {
            Life2.SetActive(false);
            Life1.SetActive(true);
        }
        else if (player.lives <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Life1.SetActive(false);
            DiePanel.SetActive(true);
        }
    }
}
