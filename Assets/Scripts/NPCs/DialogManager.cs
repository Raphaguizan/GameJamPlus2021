using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Game.Util;
using Game.Chicken;

public class DialogManager : Singleton<DialogManager>
{

    [SerializeField] TextMeshProUGUI question;
    [SerializeField] TextMeshProUGUI answer1;
    [SerializeField] TextMeshProUGUI answer2;
    [SerializeField] TextMeshProUGUI answer3;
    [SerializeField] TextMeshProUGUI answer4;
    SO_Dialog dialog;
    [SerializeField] GameObject Box;
    // Start is called before the first frame update
    void Start()
    {
        answer1.text = "";
        answer2.text = "";
        answer3.text = "";
        answer4.text = "";
        question.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartDialog(SO_Dialog dialog)
    {
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
        answer1.text = "";
        answer2.text = "";
        answer3.text = "";
        answer4.text = "";
        StartCoroutine(Replicating(dialog, replicNumber));

        if(replicNumber == dialog.itemAnswer)
        {
            if (dialog.item && dialog.hasItem)
            {
                ChickenBag.Instance.AddItem(dialog.item);
                dialog.hasItem = false;
            }
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