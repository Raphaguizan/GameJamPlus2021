using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Util;

public class TutorialScreensCtrl : Singleton<TutorialScreensCtrl>
{
    public List<ShowTutorial> tutorialsScreens;

    public static void CleanScreens()
    {
        foreach(ShowTutorial s in Instance.tutorialsScreens)
        {
            s.Close();
        }
    }
}
