using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Game.Util;

public class MainMenu : Singleton<MainMenu>
{
    [SerializeField] List<Button> buttons = new List<Button>();
    Button selectedButton;
    [SerializeField] GameObject optionsCanvas;
    [SerializeField] GameObject creditsCanvas;
    [SerializeField] TextMeshProUGUI statistics;
    [SerializeField] Animator optionsAnim;
   
    public void MouseEnter(int button)
    {
        selectedButton = buttons[button];
        TextMeshProUGUI t = selectedButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        t.fontSize = 40;
    }

    public void MouseExit(int button)
    {
        TextMeshProUGUI t = selectedButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        t.fontSize = 30;
    }

    public void StartGame()
    {
        StartCoroutine(ChangingScene("FirstCutscene"));
    }

    public void Options(bool show)
    {
        optionsCanvas.SetActive(show);
    }

    public void Credits(bool show)
    {
        creditsCanvas.SetActive(show);
    }

    public void Board()
    {
        StartCoroutine(ChangingScene("Board"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenControls()
    {
        optionsAnim.SetTrigger("OpenControls");
    }

    public void CloseControls()
    {
        optionsAnim.SetTrigger("CloseControls");
    }

    public void SetStatistics(int scapesFound)
    {
        statistics.text = "Escapes found: \n" + scapesFound + "/10";
    }

    IEnumerator ChangingScene(string scene)
    {
        ScreenTransition.Instance.FadeIn();
        yield return new WaitUntil(() => !ScreenTransition.Instance.isFading());
        SceneManager.LoadScene(scene);
    }
 
}
