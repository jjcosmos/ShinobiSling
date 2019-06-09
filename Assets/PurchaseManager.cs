using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PurchaseManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static PurchaseManager _instance;

    public static PurchaseManager Instance { get { return _instance; } }

    public int PlayerMoney;
    public int PlayerCostume;

    public costume[] Costumes;
    void Start()
    {
        if (PlayerPrefs.HasKey("playerMoney"))
        {
            PlayerMoney = PlayerPrefs.GetInt("playerMoney");
        }
        else
        {
            PlayerPrefs.SetInt("playerMoney", 0);
            PlayerMoney = 0;
        }

        if (PlayerPrefs.HasKey("playerCostume"))
        {
            PlayerCostume = PlayerPrefs.GetInt("playerCostume");
        }
        else
        {
            PlayerPrefs.SetInt("playerCostume", 1);
            PlayerCostume = 1;
        }

        if (PlayerPrefs.HasKey("currentCostume"))
        {
            PlayerCostume = PlayerPrefs.GetInt("currentCostume");
        }
        else
        {
            PlayerPrefs.SetInt("currentCostume", 1);
        }

    }
    private void Awake()
    {

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteAll();
        } 
    }
}
