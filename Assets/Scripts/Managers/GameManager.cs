using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

public class GameManager : Singleton<GameManager>
{
    public static bool onPause = false;
    public static Action UnloadScene;
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

    public void StartGame()
    {
        StartCoroutine(GoingToGame());
    }

    public void MainMenu(bool endingCutscene = false, int cutScene = 1)
    {
        UnloadScene?.Invoke();

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
        UnloadScene?.Invoke();
        if (scene == 1)
        {
            Statistics.Instance.UpdateStatistics("City");
            SceneManager.LoadScene("City");
        }

        if(scene == 2)
        {
            Statistics.Instance.UpdateStatistics("Fall");
            SceneManager.LoadScene("Fall");
        }
        if (scene == 3)
        {
            Statistics.Instance.UpdateStatistics("UFO");
            //MainMenu(true);
            SceneManager.LoadScene("UFO");
        }
        if (scene == 4)
        {
            Statistics.Instance.UpdateStatistics("Beach");
            //MainMenu(true);
            SceneManager.LoadScene("Beach");
        }
    }

    IEnumerator GoingToGame()
    {

        ScreenTransition.Instance.FadeIn();
        yield return new WaitUntil(() => !ScreenTransition.Instance.isFading());

        SceneManager.LoadScene("Game");
    }

    public void LoadAditiveScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void UnloadAditiveScene(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }
}
