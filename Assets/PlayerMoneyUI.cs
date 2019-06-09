using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMoneyUI : MonoBehaviour
{
    // Start is called before the first frame update
    PurchaseManager purchaseManager;
    TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        purchaseManager = PurchaseManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = purchaseManager.PlayerMoney.ToString();
    }
}
