using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadMenuGold : MonoBehaviour {

    private GameObject zaidejoInfo;
    public TMP_Text goldText;
    // Use this for initialization
    void Start () {
        zaidejoInfo = GameObject.Find("ZaidejoInformacija");
        goldText.text = goldText.text + zaidejoInfo.GetComponentInChildren<LoadPlayerInfo>().gold.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UpdateStoreGold()
    {
        goldText.text = "Your gold: " + zaidejoInfo.GetComponentInChildren<LoadPlayerInfo>().gold.ToString();
    }
}
