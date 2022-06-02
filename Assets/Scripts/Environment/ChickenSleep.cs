using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Chicken;

public class ChickenSleep : MonoBehaviour
{
    [SerializeField]
    private float wakeUptimeNight = 18f;
    [SerializeField]
    private float wakeUptimeDay = 6f;

    private Chicken karen;
    private void Start()
    {
        karen = GameObject.FindObjectOfType<Chicken>();
    }
    public void Sleep()
    {
        StartCoroutine(SleepFade());
    }
    IEnumerator SleepFade()
    {
        if (karen) karen.ChangeCanMove(false);
        ScreenTransition.Instance.FadeIn();

        yield return new WaitWhile(ScreenTransition.Instance.isFading);

        if (TimeController.IsDay)
            TimeController.SetTime(wakeUptimeNight);
        else
            TimeController.SetTime(wakeUptimeDay);
        ScreenTransition.Instance.FadeOut();

        yield return new WaitWhile(ScreenTransition.Instance.isFading);

        if (karen) karen.ChangeCanMove(true);
    }
}
