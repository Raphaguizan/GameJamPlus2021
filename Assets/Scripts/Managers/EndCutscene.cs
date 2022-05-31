using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class EndCutscene : MonoBehaviour
{
    [SerializeField] PlayableDirector cutscene;
    [SerializeField] PlayableDirector final;

    [SerializeField] SO_FinalCartoon cartoon;
    public void End()
    {
        if (cartoon.IsCartoon)
        {
            cartoon.ResetFinalCartoon();
            GameManager.Instance.Board();
            return;
        }
        GameManager.Instance.MainMenu(true, 1);

    }

    public void EndFirstCutscene()
    {
        GameManager.Instance.StartGame();
    }

    public void CheckCutscene()
    {
        if (cartoon.IsCartoon)
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
