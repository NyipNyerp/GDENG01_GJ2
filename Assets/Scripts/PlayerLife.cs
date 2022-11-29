using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private PlayerMovement player;

    void Awake()
    {
        Debug.Log("Press E to pickup/drop objects");
        Debug.Log("Press F to toggle flashlight on/off");
    }


    void Update()
    {
        text.SetText("x " + player.lives);
    }
}
