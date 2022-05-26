using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnimation : MonoBehaviour
{
    TextMeshProUGUI textMesh;
    [SerializeField] float interval;
    string text;
    float time;
    char[] textChar;
    int index;
    bool done;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = this.GetComponent<TextMeshProUGUI>();
        text = textMesh.text;
        textMesh.text = "";
        time = 0;
        index = 0;
        textChar = text.ToCharArray();
        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (done) return;
        time += Time.deltaTime;
        if (time > interval)
        {
            textMesh.text += textChar[index];
            index++;
            if (index >= textChar.Length) done = true;
            time = 0;
        }
    }
}
