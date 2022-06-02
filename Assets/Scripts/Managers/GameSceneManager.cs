using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject toggleGameObj;

    private void Awake()
    {
        GameManager.ChangeGameScene += Toggle;
    }

    private void OnEnable()
    {
        toggleGameObj.SetActive(true);
    }

    private void Toggle(string sceneName)
    {
        toggleGameObj.SetActive(gameObject.scene.name.Equals(sceneName));
    }

    private void OnDestroy()
    {
        GameManager.ChangeGameScene -= Toggle;
    }
}
