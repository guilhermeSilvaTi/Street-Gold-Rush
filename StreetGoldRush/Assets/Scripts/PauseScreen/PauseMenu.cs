using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject optionScreen;

    [SerializeField]
    GameObject configButton;

    [SerializeField]
    GameObject creditsButton;

    public void ActivePause()
    {
        Time.timeScale = 0;
        optionScreen.SetActive(true);
        configButton.SetActive(false);
        creditsButton.SetActive(false);
    }

    public void DisabledPause()
    {
        Time.timeScale = 1;
        optionScreen.SetActive(false);
        configButton.SetActive(true);
        creditsButton.SetActive(true);
    }
}
