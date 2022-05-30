using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EndCutscene : MonoBehaviour
{
    [SerializeField] PlayableDirector cutscene;
    [SerializeField] PlayableDirector final;
    [SerializeField] bool isFinal;
   public void End()
    {
        GameManager.Instance.MainMenu(true, 1);
    }

    public void EndFirstCutscene()
    {
        GameManager.Instance.StartGame();
    }

    public void CheckCutscene()
    {
        if(isFinal)
        {
            cutscene.Pause();
            StartCoroutine(StopCutscene());
            final.Play();
        }
    }

    IEnumerator StopCutscene()
    {
        yield return new WaitForSeconds(2f);
        cutscene.Stop();
    }
}
