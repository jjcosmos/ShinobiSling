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
    public bool disableOnStart;
    [SerializeField] int price;
    [SerializeField] ShopRefresher refresher;
    Image coinImage;
    private AudioSource audioSource;

    PurchaseManager purchaseManager;
    private GameObject PurchaseButton;

    public bool enableOnAllComplete;
    public bool enableOnAllMarathon;
    void Start()
    {
        if (!PlayerPrefs.HasKey("SpecialEnabled"))
        {
            PlayerPrefs.SetInt("SpecialEnabled", 0);
        }

        PurchaseButton = transform.GetChild(0).gameObject;
        if (disableOnStart)
        {
            PurchaseButton.SetActive(false);
        }

        if (enableOnAllComplete)
        {
            if(LevelTracker.GetAllComplete())
                PurchaseButton.SetActive(true);
        }

        if (enableOnAllMarathon)
        {
            if (LevelTracker.GetAllMarathon() || PlayerPrefs.GetInt("SpecialEnabled") == 1)
                PurchaseButton.SetActive(true);
        }


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
        audioSource = GetComponent<AudioSource>();
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

            audioSource.PlayOneShot(audioSource.clip);

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
