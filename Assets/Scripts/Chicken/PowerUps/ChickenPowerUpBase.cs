using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChickenPowerUpBase : MonoBehaviour
{
    [SerializeField]
    protected PowerUpType _name;
    [SerializeField]
    private GameObject _artObj;
    [SerializeField]
    private ShowTutorial _tutorial;
    [SerializeField]
    private UnityEvent _onActivePowerUp;



    public PowerUpType Name => _name;
    public GameObject ArtObj => _artObj;
    public ShowTutorial Tutorial => _tutorial;
    public UnityEvent OnActivePowerUp => _onActivePowerUp;

    public bool IsActive => PlayerPrefs.HasKey(GetSaveName());


    private const string saveLabel = "PWUP";

    protected virtual void Start()
    {
        SetArtActive(false);
        Load();
    }

    public virtual void Interact()
    {

    }

    public virtual void ActivePowerUp()
    {
        SetArtActive(true);

        ShowTutorial();
        
        SavePowerUp();
        OnActivePowerUp.Invoke();
    }

    public virtual void DisabePowerUp()
    {
        SetArtActive(false);

        DeleteSavePowerUp();
    }

    protected void Load()
    {
        if (PlayerPrefs.HasKey(GetSaveName()))
        {
            ActivePowerUp();
        }
    }

    protected void SavePowerUp()
    {
        if (PlayerPrefs.HasKey(GetSaveName()))
            return;

        PlayerPrefs.SetInt(GetSaveName(), 1);
    }

    protected void DeleteSavePowerUp()
    {
        PlayerPrefs.DeleteKey(GetSaveName());
    }

    protected string GetSaveName()
    {
        return saveLabel+Name.ToString();
    }

    protected void SetArtActive(bool val)
    {
        if (ArtObj != null)
            ArtObj.SetActive(val);
    }

    protected void ShowTutorial()
    {
        if (Tutorial != null)
            Tutorial.Show();
    }
}
