using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Loader : MonoBehaviour
{
    // Start is called before the first frame update
    bool loadingLevel;
    AudioSource audiosource;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int level)
    {
        audiosource.Play();
        //use coroutine to fade audio
        if (!loadingLevel)
        {
            StartCoroutine(FadeOutAndLoad(level));
        }
        loadingLevel = true;
        
    }

    IEnumerator FadeOutAndLoad(int Level)
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(Level);

    }
}
