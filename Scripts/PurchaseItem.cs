using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseItem : MonoBehaviour {
    public int indexOfItemPurchased;
    public int costOfItemPurchased;
    public GameObject storeManager;
    public Text daiktoPavadinimasText;
    public Text daiktoKainaText;
    // Use this for initialization
    void Start () {
        /*
        daiktoPavadinimasText.text = daiktoPavadinimasText.text + 
            storeManager.GetComponent<Store>().items[indexOfItemPurchased].name +" ?";
        daiktoKainaText.text = daiktoKainaText.text +
            costOfItemPurchased + " gold.";
        this.transform.FindChild("DaiktoNuotrauka").GetComponent<Image>().sprite =
            storeManager.GetComponent<Store>().items[indexOfItemPurchased].icon;
            */
    }
	public IEnumerator Buy()
    {
        GameObject zaidejoInfo = GameObject.Find("ZaidejoInformacija");
        if (zaidejoInfo.GetComponent<LoadPlayerInfo>().gold < costOfItemPurchased)
            Debug.LogWarning("Not enough gold");
        else
        {
            zaidejoInfo.GetComponent<LoadPlayerInfo>().gold= zaidejoInfo.GetComponent<LoadPlayerInfo>().gold- costOfItemPurchased;
            yield return StartCoroutine(zaidejoInfo.GetComponent<LoadPlayerInfo>().UpdateGold(
                zaidejoInfo.GetComponent<LoadPlayerInfo>().playerName, zaidejoInfo.GetComponent<LoadPlayerInfo>().gold));
            zaidejoInfo.GetComponent<LoadPlayerInfo>().unlockedItems[indexOfItemPurchased] = 1;
            yield return StartCoroutine(zaidejoInfo.GetComponent<LoadPlayerInfo>().UpdateUnlockedItems(
                zaidejoInfo.GetComponent<LoadPlayerInfo>().playerName, indexOfItemPurchased));
            GameObject.Find("ItemsParent").GetComponent<BuyButtonLoader>().DisableBuyButton(indexOfItemPurchased);
            GameObject.Find("StoreMenu").GetComponent<LoadMenuGold>().UpdateStoreGold();
            gameObject.SetActive(false);

        }
    }
    public void StartCoroutineBuy()
    {
        StartCoroutine(Buy());
    }
	// Update is called once per frame
	void Update () {
		
	}
    public void ConfirmWindowUpdate()
    {
        daiktoPavadinimasText.text = "Do you really want to buy "+
            storeManager.GetComponent<Store>().items[indexOfItemPurchased].name + " ?";
        daiktoKainaText.text = "It costs " +
            costOfItemPurchased + " gold.";
        this.transform.FindChild("DaiktoNuotrauka").GetComponent<Image>().sprite =
            storeManager.GetComponent<Store>().items[indexOfItemPurchased].icon;
    }
}
