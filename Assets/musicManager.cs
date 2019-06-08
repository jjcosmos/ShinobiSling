using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    private static musicManager _instance;

    public static musicManager Instance { get { return _instance; } }
    private AudioSource audioSource;
    public bool musicMuted;

    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Application.targetFrameRate = 60;

        
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void FadeOutAS()
    {
        StopAllCoroutines();
        StartCoroutine(LowerVolume());
    }

    IEnumerator LowerVolume()
    {
        float volume = audioSource.volume;
        while(volume > 0)
        {
            volume = audioSource.volume;
            audioSource.volume -= .1f;
            yield return new WaitForSeconds(.1f);
        }
        
        musicMuted = true;
        yield return null;
    }
}

