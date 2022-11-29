using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private PlayerMovement player;

    void Update()
    {
        text.SetText("x " + player.lives);
    }
}
