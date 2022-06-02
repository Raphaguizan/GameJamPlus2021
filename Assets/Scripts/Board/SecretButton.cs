using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretButton : MonoBehaviour
{
    [SerializeField] List<GameObject> popups = new List<GameObject>();
    [SerializeField] Animator anim;
    [SerializeField] GameObject panel;
    int index;
    bool isOpen;

    [SerializeField] Transform buttonOther;
    [SerializeField] Transform buttonKaren;

    private void Start()
    {
        index = 0;
    }
    public void OpenPopUp()
    {
        panel.SetActive(true);
        isOpen = true;
        popups[0].SetActive(true);
    }

    public void NextPopUp()
    {
        index++;
        popups[index].SetActive(true);
    }

    public void Cancel()
    {

        StartCoroutine(Canceling());
    }

    public void OpenSecretButton()
    {
        anim.SetBool("Open", true);
    }

    public void CloseSecretButton()
    {
        anim.SetBool("Open", false);
    }
    IEnumerator Canceling()
    {
        while(index >= 0)
        {
            popups[index].SetActive(false);
            yield return new WaitForSeconds(.07f);
            index--;
        }

        index = 0;
        panel.SetActive(false);
        isOpen = false;
        CloseSecretButton();
    }

}
