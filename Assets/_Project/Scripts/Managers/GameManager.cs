using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public static bool onPause = false;
    public void TogglePause()
    {
        onPause = !onPause;

        if (onPause)
        {
            PauseMenu.Instance.OpenMenu();
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            PauseMenu.Instance.CloseMenu();
        }

    }

    public void CompleteScape(int finalScene)
    {
        StartCoroutine(GoingToFinalScene(finalScene));
    }
    public void MainMenu(bool endingCutscene = false, int cutScene = 0)
    {
        if (!endingCutscene)
            TogglePause();

        StartCoroutine(GoingToMainMenu());
    }
    IEnumerator GoingToMainMenu()
    {

        ScreenTransition.Instance.FadeIn();
        yield return new WaitUntil(() => !ScreenTransition.Instance.isFading());

        SceneManager.LoadScene("MainMenu");


    }

    IEnumerator GoingToFinalScene(int scene)
    {
        ScreenTransition.Instance.FadeIn();
        yield return new WaitUntil(() => !ScreenTransition.Instance.isFading());

        if (scene == 1)
            SceneManager.LoadScene("City");
    }

}
