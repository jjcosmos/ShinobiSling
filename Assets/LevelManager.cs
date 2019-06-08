using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    musicManager music;
    bool musicStarted;
    [SerializeField] AudioClip Clip;
    [SerializeField] float Volume = 1;
    bool alreadyPlaying;
    void Start()
    {
        music = FindObjectOfType<musicManager>();
        if (music.GetComponent<AudioSource>().clip != Clip)
        {
            music.FadeOutAS();
        }
        else
        {
            alreadyPlaying = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!alreadyPlaying && !musicStarted)
        {
            if (music.musicMuted)
            {
                music.GetComponent<AudioSource>().clip = Clip;
                music.GetComponent<AudioSource>().volume = Volume;
                music.GetComponent<AudioSource>().Play();
                musicStarted = true;
                Debug.Log("UnMutingMusic");
                music.musicMuted = false;
            }
        }
    }
}
