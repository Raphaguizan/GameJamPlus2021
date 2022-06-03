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
    bool animating;
    float time;
    [SerializeField] Transform buttonOther;
    [SerializeField] Transform buttonKaren;

    private void Start()
    {
        index = 0;
    }

    void Update()
    {
        if (!animating) return;
        time += Time.deltaTime;

        if(time > .3f)
        {
            time = 0;
            animating = false;
        }
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
        if (animating) return;
        animating = true;
        anim.SetBool("Open", true);
    }

    public void CloseSecretButton()
    {
        if (animating) return;
        animating = true;
        anim.SetBool("Open", false);
    }

    public void Unlock()
    {
        Statistics.Instance.CheatOn();
        GameManager.Instance.Board();
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
       // CloseSecretButton();
    }

    public void SwapButtons()
    {
        Vector3 pos = buttonOther.position;
        buttonOther.position = buttonKaren.position;
        buttonKaren.position = pos;
    }
}
