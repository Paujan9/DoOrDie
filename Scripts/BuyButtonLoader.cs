using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuyButtonLoader : MonoBehaviour {
    
    private GameObject zaidejoInfo;
    public int[] unlockedItems;

    // Use this for initialization
    void Start () {
        zaidejoInfo = GameObject.Find("ZaidejoInformacija");
        unlockedItems = new int[zaidejoInfo.GetComponent<LoadPlayerInfo>().masyvoDydis];
        unlockedItems = zaidejoInfo.GetComponent<LoadPlayerInfo>().unlockedItems;
        addBuyButtons(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void addBuyButtons(GameObject obj)
    {
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            if (unlockedItems[i] == 0)
            {
                Transform storeSlotTransform = obj.transform.GetChild(i);
                GameObject storeSlotObject = storeSlotTransform.gameObject;
                Transform itemButtonTransform = storeSlotObject.transform.Find("ItemButton");
                GameObject itemButtonObject = itemButtonTransform.gameObject;

                Transform buyButtonTransform = itemButtonObject.transform.Find("BuyButton");
                GameObject buyButtonObject = buyButtonTransform.gameObject;
                buyButtonObject.active = true;
            }
            //print("Item button is " + itemButtonObject);

        }
    }
    public void passIndexToPurchaseWindow()
    {
        GameObject itemButtonObject = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        //GameObject storeSlotObject = this.transform.parent.gameObject;
        print("This object is " + itemButtonObject);
        GameObject.Find("ConfirmPurchasePanel").GetComponent<PurchaseItem>().indexOfItemPurchased =
            itemButtonObject.GetComponent<StoreSlot>().indexOfSlot;
        GameObject.Find("ConfirmPurchasePanel").GetComponent<PurchaseItem>().costOfItemPurchased=
            itemButtonObject.GetComponent<StoreSlot>().cost;
    }
    public void DisableBuyButton(int index)
    {
        Transform storeSlotTransform = this.transform.GetChild(index);
        GameObject storeSlotObject = storeSlotTransform.gameObject;
        Transform itemButtonTransform = storeSlotObject.transform.Find("ItemButton");
        GameObject itemButtonObject = itemButtonTransform.gameObject;

        Transform buyButtonTransform = itemButtonObject.transform.Find("BuyButton");
        GameObject buyButtonObject = buyButtonTransform.gameObject;
        buyButtonObject.active = false;
    }
}
