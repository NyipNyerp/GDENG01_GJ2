using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject OldPanel;
    [SerializeField] private GameObject NewPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void isNextPressed()
    {
        OldPanel.SetActive(false); 
        NewPanel.SetActive(true);
    }
    public void isPlayPressed()
    {
        AudioManager.instance.Stop("BGM");
        AudioManager.instance.Play("GameBGM");
        AudioManager.instance.Play("ZombieSFX");

        SceneManager.LoadScene("MainGame");
    }
}
