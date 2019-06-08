using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(LevelTracker.Level1Complete && LevelTracker.Level2Complete && LevelTracker.Level3Complete && LevelTracker.Level4Complete && LevelTracker.Level5Complete && LevelTracker.Level0Complete)
        {
            GetComponent<Animation>().Play();
            Debug.Log("showCredits");
        }
        else
        {
            Debug.Log("noShowCredits");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
