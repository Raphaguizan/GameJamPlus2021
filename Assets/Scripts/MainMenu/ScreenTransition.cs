using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenTransition : MonoBehaviour
{
    public static ScreenTransition Instance;

    #region Inspector
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeSpeed = 5f;
    [SerializeField] private List<Color> colors = new List<Color>();
    // [SerializeField] TextMeshProUGUI levelText;
    #endregion

    #region Members
    private CanvasGroup canvasGroup;
    private bool fading = false;
    private float fadeTarget = 0f;
    private float elapsedTime = 0;
    private float canvasAlpha = 1f;
    bool onGame;
    #endregion

    #region Actions
    public static Action OnComplete;
    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            canvasGroup = GetComponent<CanvasGroup>();
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            // GameManager.onClick += FadeIn;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
    {
        // SetFadeColor(scene.buildIndex);
        if (scene.buildIndex != 0)
        {
            // ToggleLevelText(true);
        }

        FadeOut();

    }

    private void Update()
    {
        if (fading)
        {
            elapsedTime += Time.deltaTime * fadeSpeed;
            canvasGroup.alpha = Mathf.Lerp(canvasAlpha, fadeTarget, elapsedTime);
            if (elapsedTime >= 1f)
            {

                canvasGroup.alpha = fadeTarget;
                fading = false;
                elapsedTime = 0;
                if (!onGame)
                    OnComplete?.Invoke();

            }
        }
    }

    public void SetFadeColor(int index)
    {
        if (fadeImage != null)
        {
            index = Mathf.Clamp(index, 0, 1);
            fadeImage.color = colors[index];
        }
    }


    public void FadeIn(bool onGame = false)
    {
        this.onGame = onGame;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        canvasAlpha = canvasGroup.alpha;
        fadeTarget = 1f;
        fading = true;
    }


    public void FadeOut()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasAlpha = canvasGroup.alpha;
        fadeTarget = 0;
        fading = true;
    }

    public void SetLevelText(int levelNumber)
    {

        // levelText.text = string.Format("Level {0}", levelNumber);
    }

    public void ToggleLevelText(bool isOn)
    {

        // levelText.gameObject.SetActive(isOn);
    }

    public bool isFading()
    {
        return fading;
    }
}
