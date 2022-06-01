using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class VerifyPassword : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputfield;
    [SerializeField]
    private GameObject errorText;

    [SerializeField]
    private string password;

    [Space]
    public UnityEvent onPasswordCorrect;

    private void OnEnable()
    {
        errorText.SetActive(false);
    }

    public void Verify()
    {
        if(inputfield.text.Equals(password))
            onPasswordCorrect.Invoke();
        else
            errorText.SetActive(true);
    }
}
