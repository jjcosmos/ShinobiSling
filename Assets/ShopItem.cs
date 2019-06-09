﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[System.Serializable]
public class ShopItem : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI priceText;
    public bool equipped;
    public bool isOwned;
    public int costumeNumber = 1;
    [SerializeField] int price;
    [SerializeField] ShopRefresher refresher;
    Image coinImage;

    PurchaseManager purchaseManager;
    void Start()
    {
        
        

        purchaseManager = PurchaseManager.Instance;

        if(PlayerPrefs.HasKey("costume_" + costumeNumber.ToString() + "_owned"))
        {
            if(PlayerPrefs.GetInt("costume_" + costumeNumber.ToString() + "_owned") == 0)
            {
                isOwned = false;
            }
            else
            {
                isOwned = true;
            }
        }

        if(purchaseManager.PlayerCostume == costumeNumber)
        {
            equipped = true;
            refresher.refreshAll(costumeNumber);
        }
        UpdateGUI();
    }

    private void Awake()
    {
        priceText = transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        priceText.text = price.ToString();
        coinImage = transform.GetChild(2).GetComponent<Image>();
    }

    public void TryPurchaseItem()
    {
        if (purchaseManager.PlayerMoney >= price && !isOwned)
        {
            isOwned = true;
            equipped = true;
            purchaseManager.PlayerCostume = costumeNumber;

            refresher.refreshAll(costumeNumber);
            UpdateGUI();

            purchaseManager.PlayerMoney -= price;

            PlayerPrefs.SetInt("costume_" + costumeNumber.ToString() + "_owned", 1); // 1 is owned, 0 is not
            PlayerPrefs.SetInt("playerMoney", purchaseManager.PlayerMoney);
            PlayerPrefs.SetInt("currentCostume", costumeNumber);
            
        }
        else if (isOwned)
        {
            equipped = true;
            purchaseManager.PlayerCostume = costumeNumber;
            refresher.refreshAll(costumeNumber);
            PlayerPrefs.SetInt("currentCostume", costumeNumber);
            UpdateGUI();
        }

    }

    private void UpdateGUI()
    {
        if (isOwned && !equipped)
        {
            priceText.text = "OFF";
            coinImage.enabled = false;
        }
        else if (equipped)
        {
            priceText.text = "ON";
            coinImage.enabled = false;
        }
    }

    public void ToggleOffAndRefresh()
    {
        if (isOwned)
        {
            equipped = false;
            coinImage.enabled = false;
        }
        UpdateGUI();
    }
}
