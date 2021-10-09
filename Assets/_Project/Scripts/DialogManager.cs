using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{

    public static DialogManager Instance;
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] TextMeshProUGUI answer1;
    [SerializeField] TextMeshProUGUI answer2;
    [SerializeField] TextMeshProUGUI answer3;
    [SerializeField] TextMeshProUGUI answer4;
    SO_Dialog dialog;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
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
        this.dialog = dialog;
        StartCoroutine(Dialoging(dialog)); ;
    }

    public void Replic( int replicNumber)
    {
        answer1.text = "";
        answer2.text = "";
        answer3.text = "";
        answer4.text = "";
        StartCoroutine(Replicating(dialog, replicNumber));

        if(replicNumber == 3)
        {
            Chicken c = GameObject.Find("Chicken").GetComponent<Chicken>();
            c.hasCarKey = true;
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