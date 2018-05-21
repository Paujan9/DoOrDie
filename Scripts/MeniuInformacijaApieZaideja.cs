using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MeniuInformacijaApieZaideja : MonoBehaviour {
    private GameObject zaidejoInfo;
    public TMP_Text vardasText;
    public TMP_Text highscoreText;
    public TMP_Text goldText;

    // Use this for initialization
    void Start () {
        zaidejoInfo = GameObject.Find("ZaidejoInformacija");
        vardasText.text = vardasText.text + zaidejoInfo.GetComponentInChildren<LoadPlayerInfo>().playerName+",";
        highscoreText.text = highscoreText.text + zaidejoInfo.GetComponentInChildren<LoadPlayerInfo>().highscore.ToString();
        goldText.text = goldText.text + zaidejoInfo.GetComponentInChildren<LoadPlayerInfo>().gold.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
