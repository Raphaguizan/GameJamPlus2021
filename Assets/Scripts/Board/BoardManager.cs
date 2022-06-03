using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{
    [SerializeField] SO_FinalCartoon cartoon;
    [SerializeField] List<PhotoButton> photos;
    [SerializeField] PlayableDirector startFinal;
    [SerializeField] GameObject panel;
    [SerializeField] Button secretButton;
    [SerializeField] Button endButton;

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

        foreach(PhotoButton pb in photos)
        {
            string name = pb.GetName();
            if(Statistics.Instance.IsCheatOn() || Statistics.Instance.IsEscapeUnlocked(name))
            {
                pb.SetLock(true);
            }
            else
            {
                pb.SetLock(false);
            }
        }

        if (Statistics.Instance.GetEscapesQuantity() == 10 || Statistics.Instance.IsCheatOn())
        {
            secretButton.interactable = false;
            secretButton.gameObject.SetActive(false);

            if (AllPhotosSeen())
            {

                endButton.interactable = true;
                endButton.gameObject.SetActive(true);
            }
        }
        else
        {
            secretButton.interactable = true;
            secretButton.gameObject.SetActive(true);
            endButton.interactable = false;
            endButton.gameObject.SetActive(false);
        }
       
    }

    bool AllPhotosSeen()
    {
        foreach(PhotoButton photo in photos)
        {
            if(!Statistics.Instance.IsPhotoSeen(photo.GetName()))
            {
                return false;
            }
        }

        return true;
    }
    public void StartFinal()
    {
        panel.SetActive(true);
        startFinal.Play();
    }

    public void GoToHell()
    {
        GameManager.Instance.CompleteScape(11);
    }
}
