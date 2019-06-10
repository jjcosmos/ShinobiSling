using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagGoal : MonoBehaviour
{
    // Start is called before the first frame update
    bool loadingMenu;
    ParticleSystem particles;
    AudioSource audiosource;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        particles = transform.GetChild(0).GetComponent<ParticleSystem>();
        particles.gameObject.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (!loadingMenu)
            {
                audiosource.Play();
                StartCoroutine(loadMenu());
                particles.gameObject.SetActive(true);
                particles.Play();
                loadingMenu = true;
                if(SceneManager.GetActiveScene().buildIndex == 1)
                {
                    LevelTracker.Level0Complete = true;
                    SaveLoadManager.level2Unlocked = "true";
                    PlayerPrefs.SetString("L2Unlocked", "true");
                    LevelTracker.Level0Marathon = true;
                }
                else if(SceneManager.GetActiveScene().buildIndex == 2)
                {
                    LevelTracker.Level1Complete = true;
                    SaveLoadManager.level3Unlocked = "true";
                    PlayerPrefs.SetString("L3Unlocked", "true");
                    LevelTracker.Level1Marathon = true;

                }
                else if (SceneManager.GetActiveScene().buildIndex == 3)
                {
                    LevelTracker.Level2Complete = true;
                    SaveLoadManager.level4Unlocked = "true";
                    PlayerPrefs.SetString("L4Unlocked", "true");
                    LevelTracker.Level2Marathon = true;

                }
                else if (SceneManager.GetActiveScene().buildIndex == 4)
                {
                    LevelTracker.Level3Complete = true;
                    SaveLoadManager.level5Unlocked = "true";
                    PlayerPrefs.SetString("L5Unlocked", "true");
                    LevelTracker.Level3Marathon = true;

                }
                else if (SceneManager.GetActiveScene().buildIndex == 5)
                {
                    LevelTracker.Level4Complete = true;
                    SaveLoadManager.level6Unlocked = "true";
                    PlayerPrefs.SetString("L6Unlocked", "true");
                    LevelTracker.Level4Marathon = true;

                }
                else if (SceneManager.GetActiveScene().buildIndex == 6)
                {
                    LevelTracker.Level5Complete = true;
                    LevelTracker.Level5Marathon = true;

                }

                if (LevelTracker.GetAllMarathon())
                {
                    PlayerPrefs.SetInt("SpecialEnabled", 1);
                }

            }
            //collision.transform.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }

    private IEnumerator loadMenu()
    {
        yield return new WaitForSeconds(2);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
