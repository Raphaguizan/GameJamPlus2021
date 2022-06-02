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
    public static Action<string> ChangeGameScene;
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
        if (!endingCutscene)
            TogglePause();

        StartCoroutine(GoingToMainMenu());
    }

    public void Board()
    {
        StartCoroutine(GoingToBoard());
    }

    public void BoardToMainMenu()
    {
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
        if (scene == 5)
        {
            Statistics.Instance.UpdateStatistics("Jail");
            //MainMenu(true);
            SceneManager.LoadScene("Jail");
        }
        if (scene == 6)
        {
            Statistics.Instance.UpdateStatistics("Server");
            SceneManager.LoadScene("Server");
        }

        if (scene == 7)
        {
            Statistics.Instance.UpdateStatistics("Simulation");
            SceneManager.LoadScene("Simulation");
        }
        if (scene == 8)
        {
            Statistics.Instance.UpdateStatistics("MagicalPlace");
            //MainMenu(true);
            SceneManager.LoadScene("MagicalPlace");
        }
        if (scene == 9)
        {
            Statistics.Instance.UpdateStatistics("Heaven");
            //MainMenu(true);
            SceneManager.LoadScene("Heaven");
        }
        if (scene == 10)
        {
            Statistics.Instance.UpdateStatistics("School");
            //MainMenu(true);
            SceneManager.LoadScene("School");
        }
        if (scene == 11)
        {
            Statistics.Instance.UpdateStatistics("Hell");
            //MainMenu(true);
            SceneManager.LoadScene("Hell");
        }
    }

    IEnumerator GoingToGame()
    {

        ScreenTransition.Instance.FadeIn();
        yield return new WaitUntil(() => !ScreenTransition.Instance.isFading());

        SceneManager.LoadScene("Game");
    }

    IEnumerator GoingToBoard()
    {

        ScreenTransition.Instance.FadeIn();
        yield return new WaitUntil(() => !ScreenTransition.Instance.isFading());

        SceneManager.LoadScene("Board");
    }

    public void LoadGameScene(string sceneName)
    {
        StartCoroutine(GoingToGameScene(sceneName));
    }

    IEnumerator GoingToGameScene(string sceneName)
    {
        ChangeGameScene?.Invoke(sceneName);
        ScreenTransition.Instance.FadeIn();
        yield return new WaitUntil(() => !ScreenTransition.Instance.isFading());

        if(!IsSceneLoaded(sceneName))
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }

    private bool IsSceneLoaded(string name)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name.Equals(name))
                return true;
        }
        return false;
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
