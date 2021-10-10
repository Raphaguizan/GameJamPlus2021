using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] List<Button> buttons = new List<Button>();
    Button selectedButton;
    [SerializeField] Animator signAnim;
    [SerializeField] Animator titleAnim;
    [SerializeField] Animator canvasAnim;
   
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

    }

    public void Options()
    {

    }

    public void Credits()
    {

    }

    public void Statistics()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void CallAnimationSign()
    {
        signAnim.SetTrigger("start");
    }

    public void CallAnimationCanvas()
    {
        canvasAnim.SetTrigger("start");
    }

    public void CallAnimationTitle()
    {
        titleAnim.SetTrigger("start");
    }
}
