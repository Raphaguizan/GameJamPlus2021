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
    Image image;
    bool skiped = false;
    // Start is called before the first frame update
    void Start()
    {
        image = this.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pressing)
        {
            time += Time.deltaTime;
            image.fillAmount = 1 - (time / waitTime);
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
        image.fillAmount = 1;
    }
}
