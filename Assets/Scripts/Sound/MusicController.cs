using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource music;

    // Update is called once per frame
    void Update()
    {
        if(TimeController.IsDay){
            music.pitch = 1f;
        }else{
            music.pitch = 0.8f;
        }
    }
}
