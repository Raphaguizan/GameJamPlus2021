using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    [SerializeField] GameObject glassButton;
    [SerializeField] Animator anim;
    [SerializeField] GameObject canvas;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenGlass()
    {
        anim.SetTrigger("Open");
        glassButton.GetComponent<Button>().interactable = false;
        glassButton.SetActive(false);
    }

    public void PushButton()
    {
        anim.SetTrigger("Push");
        
    }

    public void OpenPopup()
    {
        canvas.SetActive(true);
    }

    public void ClosePopup()
    {
        canvas.SetActive(false);
        anim.SetTrigger("Close");
        glassButton.SetActive(true);
        glassButton.GetComponent<Button>().interactable = true;
    }


    public void ResetAll()
    {
        Statistics.Instance.ResetAll();
        GameManager.Instance.Board();
    }
}
