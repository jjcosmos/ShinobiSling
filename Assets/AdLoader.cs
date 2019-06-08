using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdLoader : MonoBehaviour
{
    // Start is called before the first frame update
    bool isAdShowing;
    void Start()
    {
        Advertisement.Initialize("3177854");
        isAdShowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAdShowing && Advertisement.IsReady("OnMenu"))
        {

            Advertisement.Show("OnMenu");
            isAdShowing = true;
        }
    }
}
