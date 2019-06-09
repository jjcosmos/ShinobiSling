using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;
using TMPro;
public class AdLoader : MonoBehaviour
{
    // Start is called before the first frame update
    // 3177854
    // BannerAd
    public bool isAdShowing;
    private string store_id = "3177854";
    private string video_ad = "video";
    private string banner_ad = "BannerAd";
    private string reward_ad = "rewardedVideo";
    private bool rewardedForCurrentAd;
    public bool debugTextOn;
    [SerializeField] bool testModeOn;
    [SerializeField] TextMeshProUGUI debugText;
    ShowAdPlacementContent ad;

    void Start()
    {
        isAdShowing = false;
        Monetization.Initialize(store_id, testModeOn);
        debugText.text = "";
    }

    private void Update()
    {
        if (Monetization.IsReady(reward_ad) && debugTextOn)
        {
            debugText.text = "MonReady : Initialized = " + Monetization.isInitialized;
        }
        else if(debugTextOn)
        {
            debugText.text = "MonWaiting : Initialized = " + Monetization.isInitialized;
        }
        if(ad != null)
        {
            if (debugTextOn)
            {
                debugText.text = debugText.text + " : isShowing = " + ad.showing + " rw: " + ad.rewarded;
            }

            if (ad.rewarded && !rewardedForCurrentAd)
            {
                
                rewardedForCurrentAd = true;
                PurchaseManager.Instance.PlayerMoney += 10;
                PlayerPrefs.SetInt("playerMoney", PurchaseManager.Instance.PlayerMoney);
            }
        }
    }

    public void ShowAd()
    {
        if (Monetization.IsReady(reward_ad))
        {
            ad = null;
            ad = Monetization.GetPlacementContent(reward_ad) as ShowAdPlacementContent;

            if (ad != null)
            {
                rewardedForCurrentAd = false;
                ad.Show();
                isAdShowing = true;
                Debug.Log(ad.placementId);

                
            }
        }
    }

    

}

    