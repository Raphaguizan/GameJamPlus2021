using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTutorial : MonoBehaviour
{
    public float time;

    [SerializeField]
    private GameObject _toShow;

    private void Start()
    {
        Close();
    }

    public void Show()
    {
        _toShow.SetActive(true);
        StartCoroutine(Showing());
    }

    IEnumerator Showing()
    {
        yield return new WaitForSeconds(time);
        Close();
    }
    
    public void Close()
    {
        _toShow.SetActive(false);
    }
}
