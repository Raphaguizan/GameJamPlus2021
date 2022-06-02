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
    [SerializeField] private float fadeInSpeed = 5f;
    [Tooltip("in seconds")] public float fadeOutDelay = 1f;
    [SerializeField] private float fadeOutSpeed = 1f;
    [SerializeField] private List<Color> colors = new List<Color>();
    // [SerializeField] TextMeshProUGUI levelText;
    #endregion

    #region Members
    private CanvasGroup canvasGroup;
    private bool fading = false;
    private float fadeTarget = 0f;
    private float elapsedTime = 0;
    private float canvasAlpha = 1f;
    private float currentFadeSpeed;
    bool onGame;
    #endregion

    #region Actions
    public static Action OnComplete;
    public static Action OnStart;
    #endregion

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            currentFadeSpeed = fadeInSpeed;
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
            OnStart?.Invoke();
            elapsedTime += Time.deltaTime * currentFadeSpeed;
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
        currentFadeSpeed = fadeInSpeed;
        fadeTarget = 1f;
        fading = true;
    }


    public void FadeOut()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        canvasAlpha = canvasGroup.alpha;
        currentFadeSpeed = fadeOutSpeed;
        fadeTarget = 0;
        StartCoroutine(FadeDelay());
    }
    IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(fadeOutDelay);
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
