using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopRefresher : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ShopItem[] Items;
    public void refreshAll(int currentlyToggledCostume)
    {
        foreach (ShopItem item in Items)
        {
            if(item.costumeNumber != currentlyToggledCostume)
            {
                item.ToggleOffAndRefresh();
                Debug.Log("Refreshed " + item.costumeNumber.ToString());
            }
            else
            {
                item.equipped = true;
                
            }
        }
    }
}
