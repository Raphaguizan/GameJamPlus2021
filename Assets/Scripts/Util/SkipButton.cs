using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class SkipButton : MonoBehaviour
{
    [SerializeField] float waitTime;
    [SerializeField] PlayableDirector timeline;
    bool pressing;
    float time;
    [SerializeField] Image image;
    bool skiped = false;
  
    void Update()
    {
        if (pressing)
        {
            time += Time.deltaTime;
            image.fillAmount = (time / waitTime);
            if (time >= waitTime && !skiped)
            {
                Debug.Log("skipping");
                timeline.Stop();
                GameManager.Instance.StartGame();
                skiped = true;
                this.transform.parent.gameObject.SetActive(false);

            }
        }
    }

    public void StartPress()
    {
        pressing = true;
    }

    public void StopPress()
    {
        pressing = false;
        time = 0;
        image.fillAmount = 0;
    }
}
