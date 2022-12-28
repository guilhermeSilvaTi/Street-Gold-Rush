using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    [SerializeField]
    GameObject windowsExit;
    void Update()
    {
            if (Input.backButtonLeavesApp || Input.GetKeyDown(KeyCode.Escape) )
            {
                ExitActive();
            }
    }

    public void Continue()
    {
        Time.timeScale = 1;
        windowsExit.SetActive(false);
    }
    public void ExitActive()
    {
        Time.timeScale = 0;
        windowsExit.SetActive(true);
    }

    public void  QuitGame()
    {
        // Quit the application
        Application.Quit();
    }
}
