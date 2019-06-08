using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isAdShowing;
    void Start()
    {
        Advertisement.Initialize("3177854");
        isAdShowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!isAdShowing && Advertisement.IsReady("video"))
        {

            Advertisement.Show("video");
            isAdShowing = true;
        }
        else
        {
            Debug.Log(Advertisement.IsReady("video").ToString());
        }
        
    }
}
