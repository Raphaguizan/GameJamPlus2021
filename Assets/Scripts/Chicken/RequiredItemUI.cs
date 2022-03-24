using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RequiredItemUI : MonoBehaviour
{
    public GameObject baloon;
    public Image itemSprite;
    public float showTime = 2f;
   
    private Canvas canvas;
    private Coroutine _currentCoroutine = null;
    // Start is called before the first frame update
    void Start()
    {
        baloon.SetActive(false);
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
        baloon.SetActive(true);
        itemSprite.sprite = img;
        yield return new WaitForSeconds(showTime);
        baloon.SetActive(false);
    }
}
