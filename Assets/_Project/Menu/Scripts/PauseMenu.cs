using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;

public class PauseMenu : Singleton<PauseMenu>
{
    [SerializeField] GameObject optionsCanvas;

    public void OpenMenu()
    {
        optionsCanvas.SetActive(true);
    }

    public void CloseMenu()
    {
        optionsCanvas.SetActive(false);
    }

    public void ContinueButton()
    {
        GameManager.Instance.TogglePause();
    }

    public void MainMenu()
    {
        GameManager.Instance.MainMenu();
    }
}
