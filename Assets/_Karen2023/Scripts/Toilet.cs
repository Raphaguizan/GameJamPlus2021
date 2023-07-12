using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

public class Toilet : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cm_camera;
    [SerializeField] PlayableDirector enterToiletTimeline;
    [SerializeField] ChickenPositionHelper cph;
    [SerializeField] Transform chickenPositionPoint;

    private void Start()
    {
       // this.GetComponent<ConsumeItem>().Event.AddListener(Activate);
    }

    public void Activate()
    {

        cph.SetPosition(chickenPositionPoint);
        cm_camera.gameObject.SetActive(true);

    }

    public void EnterToiletCutscene()
    {
        enterToiletTimeline.Play();
        enterToiletTimeline.stopped += EndCutscene;
    }

    void EndCutscene(PlayableDirector tl)
    {
        enterToiletTimeline.stopped -= EndCutscene;
        GameManager.Instance.LoadGameScene("DropToSchoolEntrance");

    }
}
