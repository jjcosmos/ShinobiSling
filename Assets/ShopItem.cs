using System.Collections;
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

    PurchaseManager purchaseManager;
    void Start()
    {
        priceText = transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        priceText.text = price.ToString();
        

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

        if (PlayerPrefs.HasKey("currentCostume"))
        {
            refresher.refreshAll(PlayerPrefs.GetInt("currentCostume"));
        }
        else
        {
            PlayerPrefs.SetInt("currentCostume", 1);
        }

        UpdateGUI();
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
        }
        else if (equipped)
        {
            priceText.text = "ON";
        }
    }

    public void ToggleOffAndRefresh()
    {
        if (isOwned)
        {
            equipped = false;
        }
        UpdateGUI();
    }
}
