using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SaveLoadManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static SaveLoadManager _instance;

    public static SaveLoadManager Instance { get { return _instance; } }

    public static string level2Unlocked;
    public static string level3Unlocked;
    public static string level4Unlocked;
    public static string level5Unlocked;
    public static string level6Unlocked;

    [SerializeField] Image L2Lock;
    [SerializeField] Image L3Lock;
    [SerializeField] Image L4Lock;
    [SerializeField] Image L5Lock;
    [SerializeField] Image L6Lock;

    [SerializeField] Button L2Button;
    [SerializeField] Button L3Button;
    [SerializeField] Button L4Button;
    [SerializeField] Button L5Button;
    [SerializeField] Button L6Button;


    void Start()
    {
        SaveEncodedFile();

        level2Unlocked = "false";
        level3Unlocked = "false";
        level4Unlocked = "false";
        level5Unlocked = "false";
        level6Unlocked = "false";

        this.LoadEncodedFile();


        UpdateLocks();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            ClearCompletedLevels();
            SaveEncodedFile();
        }
    }

    public static void SaveEncodedFile()
    {
        PlayerPrefs.SetString("L2Ulocked", level2Unlocked);
        PlayerPrefs.SetString("L3Ulocked", level3Unlocked);
        PlayerPrefs.SetString("L4Ulocked", level4Unlocked);
        PlayerPrefs.SetString("L5Ulocked", level5Unlocked);
        PlayerPrefs.SetString("L6Ulocked", level6Unlocked);
    }

    public void LoadEncodedFile()
    {
        if (PlayerPrefs.HasKey("L2Unlocked"))
        {
            level2Unlocked = PlayerPrefs.GetString("L2Unlocked");
        }
        else
        {
            PlayerPrefs.SetString("L2Unlocked", level2Unlocked);
        }
        ///

        if (PlayerPrefs.HasKey("L3Unlocked"))
        {
            level3Unlocked = PlayerPrefs.GetString("L3Unlocked");
        }
        else
        {
            PlayerPrefs.SetString("L3Unlocked", level3Unlocked);
        }
        ///

        if (PlayerPrefs.HasKey("L4Unlocked"))
        {
            level4Unlocked = PlayerPrefs.GetString("L4Unlocked");
        }
        else
        {
            PlayerPrefs.SetString("L4Unlocked", level4Unlocked);
        }
        ///

        if (PlayerPrefs.HasKey("L5Unlocked"))
        {
            level5Unlocked = PlayerPrefs.GetString("L5Unlocked");
        }
        else
        {
            PlayerPrefs.SetString("L5Unlocked", level5Unlocked);
        }
        ///

        if (PlayerPrefs.HasKey("L6Unlocked"))
        {
            level6Unlocked = PlayerPrefs.GetString("L6Unlocked");
        }
        else
        {
            PlayerPrefs.SetString("L6Unlocked", level6Unlocked);
        }
        ///
    }

    public static void ClearCompletedLevels()
    {
        PlayerPrefs.SetString("L2Unlocked", "false");
        PlayerPrefs.SetString("L3Unlocked", "false");
        PlayerPrefs.SetString("L4Unlocked", "false");
        PlayerPrefs.SetString("L5Unlocked", "false");
        PlayerPrefs.SetString("L6Unlocked", "false");
    }

    private void UpdateLocks()
    {
        if(level2Unlocked == "true")
        {
            L2Lock.enabled = false;
            L2Button.interactable = true;
        }
        else
        {
            Debug.Log("level 2 unlock state is " + level2Unlocked);
        }

        if (level3Unlocked == "true")
        {
            L3Lock.enabled = false;
            L3Button.interactable = true;
        }

        if (level4Unlocked == "true")
        {
            L4Lock.enabled = false;
            L4Button.interactable = true;
        }

        if (level5Unlocked == "true")
        {
            L5Lock.enabled = false;
            L5Button.interactable = true;
        }

        if (level6Unlocked == "true")
        {
            L6Lock.enabled = false;
            L6Button.interactable = true;
        }
    }
}
