using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSlot : MonoBehaviour {

    public GameObject storeManager;
    private GameObject zaidejoInfo;

    //List<Item> items;
    Item item;

    public int indexOfSlot;
    public int cost;

    public void Start()
    {
        item = storeManager.GetComponent<Store>().items[indexOfSlot];
        zaidejoInfo = GameObject.Find("ZaidejoInformacija");
        //items = storeManager.GetComponent<Store>().items;
    }
    public void UseItem()
    {
        //Debug.Log(items.Count);
        //if(items[indexOfSlot] !=null)
        //{
        //items[indexOfSlot].Use();
        if (zaidejoInfo.GetComponent<LoadPlayerInfo>().unlockedItems[indexOfSlot] == 1)
            item.Use(indexOfSlot);
        else
            Debug.LogWarning("Jus dar neturite nusipirke sio daikto");
        //}
        
    }
    public void RemoveItem()
    {

        //if (items[indexOfSlot] != null)
        //{
        //items[indexOfSlot].Remove();
        //Debug.Log(indexOfSlot);
        //if(indexOfSlot== storeManager.GetComponent<Store>().items.IndexOf(item))
            item.Remove(indexOfSlot);
        //}
    }
}
