using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGameManager : MonoBehaviour
{
    public void LoadGameScene(string name)
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.LoadGameScene(name);
        }
    }

    public void CompleteScape (int num)
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.CompleteScape(num);
        }
    }
}
