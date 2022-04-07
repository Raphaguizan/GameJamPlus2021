using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;

public class RequiredItemUI : MonoBehaviour
{
    public Animator baloon;
    public Image itemSprite;
    public float showTime = 2f;
    [Header("Ballon ANimation")]
    public bool baloonIsOpen = false;
    public string openBool = "Open";
   
    private Canvas canvas;
    private Coroutine _currentCoroutine = null;

    #region TESTE
    [Header("TESTE")]
    public Sprite teste;

    [Button]
    public void ShowTeste()
    {
        ShowBaloon(teste);
    }
    #endregion

    private void Start()
    {
        baloon.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }

    private void OnValidate()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
    }

    public void ShowBaloon(Sprite img)
    {
        if(_currentCoroutine != null) StopCoroutine(_currentCoroutine);
        _currentCoroutine = StartCoroutine(BallonTime(img));
    }

    IEnumerator BallonTime(Sprite img)
    {
        if (baloon != null) baloon.SetBool(openBool, true);
        itemSprite.sprite = img;
        yield return new WaitForSeconds(showTime + 1f);//(+1) a animação de abrir tem 1 seg
        if (baloon != null) baloon.SetBool(openBool, false);
    }
}
