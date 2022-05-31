using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] SO_FinalCartoon cartoon;

    private void OnEnable()
    {
        SetPhotos();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RememberCutscene(int cutscene)
    {
        cartoon.ActiveFinalCartoon();
        GameManager.Instance.CompleteScape(cutscene);
    }

    public void SetPhotos()
    {
        for (int escape = 1; escape <= 10; escape++)
        {
            //if (escape == 1)
            //{
            //    if (Statistics.Instance.IsEscapeUnlocked("City") == ;
            //}

            //if (escape == 2)
            //{
            //    if (Statistics.Instance.IsEscapeUnlocked("Fall") == ;
            //}

            //if (escape == 3)
            //{
            //    if (Statistics.Instance.IsEscapeUnlocked("UFO") == ;
            //}

            //if (escape == 4)
            //{
            //    if (Statistics.Instance.IsEscapeUnlocked("Beach") == ;
            //}

            //if (escape == 5)
            //{
            //    if (Statistics.Instance.IsEscapeUnlocked("Jail") == ;
            //}

            //if (escape == 6)
            //{
            //    if (Statistics.Instance.IsEscapeUnlocked("Server") == ;
            //}

            //if (escape == 7)
            //{
            //    if (Statistics.Instance.IsEscapeUnlocked("Simulation") == ;
            //}

            //if (escape == 8)
            //{
            //    if (Statistics.Instance.IsEscapeUnlocked("MagicalPlace") == ;
            //}

            //if (escape == 9)
            //{
            //    if (Statistics.Instance.IsEscapeUnlocked("Heaven") == ;
            //}

            //if (escape == 10)
            //{
            //    if (Statistics.Instance.IsEscapeUnlocked("School") == ;
            //}
        }
    }
}
