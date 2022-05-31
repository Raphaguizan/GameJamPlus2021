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
        this.gameObject.SetActive(unlocked) ;
        this.unlocked = unlocked;

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
    }

    public void MouseExit()
    {
        text.fontSize = 0.015f;
    }
}
