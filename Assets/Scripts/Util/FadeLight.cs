using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Game.Util
{
    [RequireComponent(typeof(Light))]
    public class FadeLight : MonoBehaviour
    {
        [SerializeField]
        private float delay = 1f;
        [SerializeField]
        private float fadeTime = 1f;

        [Space, SerializeField]
        private Ease ease = Ease.Linear;

        private Light myLight;
        private float initialIntensity;

        private Tween mytween;
        private Coroutine myCoroutine;

        private void Awake()
        {
            myLight = GetComponent<Light>();
            initialIntensity = myLight.intensity;
        }

        private void OnEnable()
        {
            myLight.intensity = 0;
            myCoroutine = StartCoroutine(DelayTime());
        }

        IEnumerator DelayTime()
        {
            yield return new WaitForSeconds(delay);
            Fade();
        }

        private void Update()
        {
            AdjustColor();
        }

        private void AdjustColor()
        {
            myLight.color = TimeController.GetTimeColor();
        }

        private void Fade()
        {
            mytween = myLight.DOIntensity(initialIntensity, fadeTime);
        }

        private void OnDisable()
        {
            mytween.Kill();
            StopCoroutine(myCoroutine);
        }
    }
}