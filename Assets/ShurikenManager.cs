using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShurikenManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image Shuriken1;
    [SerializeField] Image Shuriken2;
    [SerializeField] Image Shuriken3;
    [SerializeField] Image Shuriken4;
    [SerializeField] Image Shuriken5;
    [SerializeField] Image Shuriken6;
    void Start()
    {
        Shuriken1.enabled = false;
        Shuriken2.enabled = false;
        Shuriken3.enabled = false;
        Shuriken4.enabled = false;
        Shuriken5.enabled = false;
        Shuriken6.enabled = false;


        if (LevelTracker.Level0Complete || PlayerPrefs.GetString("L2Unlocked") == "true")
        {
            PlayerPrefs.SetInt("L0_Complete", 1);
        }
        if (LevelTracker.Level1Complete || PlayerPrefs.GetString("L3Unlocked") == "true")
        {
            PlayerPrefs.SetInt("L1_Complete", 1);
        }
        if (LevelTracker.Level2Complete || PlayerPrefs.GetString("L4Unlocked") == "true")
        {
            PlayerPrefs.SetInt("L2_Complete", 1);
        }
        if (LevelTracker.Level3Complete || PlayerPrefs.GetString("L5Unlocked") == "true")
        {
            PlayerPrefs.SetInt("L3_Complete", 1);
        }
        if (LevelTracker.Level4Complete || PlayerPrefs.GetString("L6Unlocked") == "true")
        {
            PlayerPrefs.SetInt("L4_Complete", 1);
        }
        if (LevelTracker.Level5Complete)
        {
            PlayerPrefs.SetInt("L5_Complete", 1);
        }





        if (PlayerPrefs.HasKey("L0_Complete"))
        {
            if(PlayerPrefs.GetInt("L0_Complete") == 0)
            {
                LevelTracker.Level0Complete = false;
            }
            else
            {
                LevelTracker.Level0Complete = true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("L0_Complete", 0);
        }

        ///////
        if (PlayerPrefs.HasKey("L1_Complete"))
        {
            if (PlayerPrefs.GetInt("L1_Complete") == 0)
            {
                LevelTracker.Level1Complete = false;
            }
            else
            {
                LevelTracker.Level1Complete = true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("L1_Complete", 0);
        }

        //////
        if (PlayerPrefs.HasKey("L2_Complete"))
        {
            if (PlayerPrefs.GetInt("L2_Complete") == 0)
            {
                LevelTracker.Level2Complete = false;
            }
            else
            {
                LevelTracker.Level2Complete = true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("L2_Complete", 0);
        }

        //////
        if (PlayerPrefs.HasKey("L3_Complete"))
        {
            if (PlayerPrefs.GetInt("L3_Complete") == 0)
            {
                LevelTracker.Level3Complete = false;
            }
            else
            {
                LevelTracker.Level3Complete = true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("L3_Complete", 0);
        }

        //////
        if (PlayerPrefs.HasKey("L4_Complete"))
        {
            if (PlayerPrefs.GetInt("L4_Complete") == 0)
            {
                LevelTracker.Level4Complete = false;
            }
            else
            {
                LevelTracker.Level4Complete = true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("L4_Complete", 0);
        }

        ////
        if (PlayerPrefs.HasKey("L5_Complete"))
        {
            if (PlayerPrefs.GetInt("L5_Complete") == 0)
            {
                LevelTracker.Level5Complete = false;
            }
            else
            {
                LevelTracker.Level5Complete = true;
            }
        }
        else
        {
            PlayerPrefs.SetInt("L5_Complete", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelTracker.Level0Complete)
        {
            Shuriken1.enabled = true;
            if (LevelTracker.Level0Marathon)
            {
                Shuriken1.color = Color.red;
            }
        }
        if (LevelTracker.Level1Complete)
        {
            Shuriken2.enabled = true;
            if (LevelTracker.Level1Marathon)
            {
                Shuriken2.color = Color.red;
            }
        }
        if (LevelTracker.Level2Complete)
        {
            Shuriken3.enabled = true;
            if (LevelTracker.Level2Marathon)
            {
                Shuriken3.color = Color.red;
            }
        }
        if (LevelTracker.Level3Complete)
        {
            Shuriken4.enabled = true;
            if (LevelTracker.Level3Marathon)
            {
                Shuriken4.color = Color.red;
            }
        }
        if (LevelTracker.Level4Complete)
        {
            Shuriken5.enabled = true;
            if (LevelTracker.Level4Marathon)
            {
                Shuriken5.color = Color.red;
            }
        }
        if (LevelTracker.Level5Complete)
        {
            Shuriken6.enabled = true;
            if (LevelTracker.Level5Marathon)
            {
                Shuriken6.color = Color.red;
            }
        }
    }
}
