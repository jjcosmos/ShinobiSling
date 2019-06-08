using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;
public class AdLoader : MonoBehaviour
{
    // Start is called before the first frame update
    // 3177854
    // BannerAd
    public bool isAdShowing;
    private string store_id = "3177854";
    private string banner_ad = "BannerAd";
    private string reward_ad = "rewardedVideo";

    [SerializeField] bool testModeOn;

    void Start()
    {
        isAdShowing = false;
        Monetization.Initialize(store_id, testModeOn);
    }

    private void Update()
    {
        
    }

    public void ShowAd()
    {
        if (Monetization.IsReady(reward_ad))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(banner_ad) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show();
                isAdShowing = true;
                Debug.Log(ad.placementId);
            }
        }
    }

    

}

    