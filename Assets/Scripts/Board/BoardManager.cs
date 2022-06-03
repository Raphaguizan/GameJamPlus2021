using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] SO_FinalCartoon cartoon;
    [SerializeField] List<PhotoButton> photos;

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
       
    }
}
