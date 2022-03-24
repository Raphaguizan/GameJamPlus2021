using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;

public class PauseMenu : Singleton<PauseMenu>
{
    [SerializeField] GameObject optionsCanvas;
    [SerializeField] Animator chickenMenu;

    public void OpenMenu()
    {
        optionsCanvas.SetActive(true);
    }

    public void CloseMenu()
    {
        optionsCanvas.GetComponent<PauseCanvas>().CloseMenu();
       
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
