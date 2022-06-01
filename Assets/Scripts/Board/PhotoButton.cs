using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhotoButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject note;
    [SerializeField] int id;
    [SerializeField] new string name;
    [SerializeField] ChickenThoughts thought;
    [SerializeField] BoardManager board;

    bool unlocked;
    bool seen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLock(bool unlocked)
    {
        this.transform.GetChild(0).gameObject.SetActive(unlocked) ;
        this.unlocked = unlocked;

        if(unlocked)
        {

            this.transform.GetChild(0).gameObject.SetActive(true);
            text.text = name;
            if (Statistics.Instance.IsPhotoSeen(name))
            {
                SetSeen(true);
            }
            else
            {
                SetSeen(false);
            }
        }
        else
        {
            this.transform.GetChild(0).gameObject.SetActive(false);
            text.text = "?";
            SetSeen(false);
        }
    }

    public void SetSeen(bool seen)
    {
        note.SetActive(seen);
        this.seen = seen;
       
    }

    public string GetName()
    {
        return name;
    }

    public void MouseOver()
    {
        text.fontSize = 0.017f;
        if(name == "MainMenu")
        {
            thought.Think("Let's get back");
            return;
        }
        if(!unlocked)
        {
            thought.LockedThink();
        }
        else if(unlocked && !seen)
        {
            thought.UnlockedThink();
        }
        else if(seen)
        {
            thought.SeenThink();
        }
    }

    public void MouseExit()
    {
        text.fontSize = 0.015f;
    }

    public void Play()
    {
        if (!unlocked)
        {

            return;
        }
        if (!Statistics.Instance.IsPhotoSeen(name))
        {
            Statistics.Instance.PhotoSeen(name);
        }
        board.RememberCutscene(id);
    }

  
}
