using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Game.Util;
using Game.Chicken;

public class DialogManager : Singleton<DialogManager>
{
    [SerializeField]
    private List<Button> buttons;

    [Space, SerializeField] TextMeshProUGUI question;
    [SerializeField] TextMeshProUGUI answer1;
    [SerializeField] TextMeshProUGUI answer2;
    [SerializeField] TextMeshProUGUI answer3;
    [SerializeField] TextMeshProUGUI answer4;
    SO_Dialog dialog;
    [SerializeField] GameObject Box;

    public static Action<bool> Answered;
    // Start is called before the first frame update
    void Start()
    {
        answer1.text = "";
        answer2.text = "";
        answer3.text = "";
        answer4.text = "";
        question.text = "";
    }

    public void StartDialog(SO_Dialog dialog)
    {
        ActiveButtons(true);
        Box.GetComponent<Animator>().SetTrigger("Open");
        this.dialog = dialog;
        StartCoroutine(Dialoging(dialog)); ;
    }
    public void CloseDialog()
    {
        Box.GetComponent<Animator>().SetTrigger("Close");
    }

    public void Replic( int replicNumber)
    {
        ActiveButtons(false);
        answer1.text = "";
        answer2.text = "";
        answer3.text = "";
        answer4.text = "";
        StartCoroutine(Replicating(dialog, replicNumber));

        Answered?.Invoke(dialog.correctAnswerIndexList.Contains(replicNumber));
    }

    private void ActiveButtons(bool val)
    {
        foreach (Button b in buttons)
        {
            b.interactable = val;
        }
    }

    IEnumerator Dialoging(SO_Dialog dialog)
    {
        string text = dialog.question;
        string actualText = "";

        foreach (char t in text)
        {
            actualText += t;
            question.text = actualText;
            yield return null;
        }

        answer1.text = dialog.answer[0];
        answer2.text = dialog.answer[1];
        answer3.text = dialog.answer[2];
        answer4.text = dialog.answer[3];

    }

    IEnumerator Replicating(SO_Dialog dialog, int n)
    {
        string text = dialog.replica[n];
        string actualText = "";

        foreach (char t in text)
        {
            actualText += t;

            question.text = actualText;
            yield return null;
        }
    }
}