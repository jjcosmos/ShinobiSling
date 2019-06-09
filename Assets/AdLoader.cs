using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;
using TMPro;
using UnityEngine.UI;
public class AdLoader : MonoBehaviour
{
    // Start is called before the first frame update
    // 3177854
    // BannerAd
    public bool isAdShowing;
    private string store_id = "3177854";
    private string apple_store_id = "3177855";
    private string video_ad = "video";
    private string banner_ad = "BannerAd";
    private string reward_ad = "rewardedVideo";
    private bool rewardedForCurrentAd;
    public bool debugTextOn;
    public bool AndroidBuild = true;
    bool hasAdStarted;
    [SerializeField] bool testModeOn;
    [SerializeField] TextMeshProUGUI debugText;
    ShowAdPlacementContent ad;

    [SerializeField] GameObject LoadingGUI;

    void Start()
    {
        isAdShowing = false;
        
        if(AndroidBuild)
        {
            Monetization.Initialize(store_id, testModeOn);
        }
        else
        {
            Monetization.Initialize(apple_store_id, testModeOn);
        }

        LoadingGUI.SetActive(false);
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
                PurchaseManager.Instance.PlayerMoney += 5;
                PlayerPrefs.SetInt("playerMoney", PurchaseManager.Instance.PlayerMoney);
            }
        }
    }

    public void ShowAd()
    {
        /*
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
        */

        StopAllCoroutines();
        StartCoroutine(ShowAdBuffered());
    }

    private IEnumerator ShowAdBuffered()
    {
        hasAdStarted = false;
        float timer = 0;
        LoadingGUI.SetActive(true);
        while (!hasAdStarted && timer < 10)
        {
            timer += Time.deltaTime;
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
                    hasAdStarted = true;


                }
            }
            yield return null;
        }
        LoadingGUI.SetActive(false);
    }

    

}

    