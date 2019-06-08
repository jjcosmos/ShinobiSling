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
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelTracker.Level0Complete)
        {
            Shuriken1.enabled = true;
        }
        if (LevelTracker.Level1Complete)
        {
            Shuriken2.enabled = true;
        }
        if (LevelTracker.Level2Complete)
        {
            Shuriken3.enabled = true;
        }
        if (LevelTracker.Level3Complete)
        {
            Shuriken4.enabled = true;
        }
        if (LevelTracker.Level4Complete)
        {
            Shuriken5.enabled = true;
        }
        if (LevelTracker.Level5Complete)
        {
            Shuriken6.enabled = true;
        }
    }
}
