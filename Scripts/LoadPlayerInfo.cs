
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayerInfo : MonoBehaviour {

    public string infoEilute;
    public string playerName;
    public int highscore;
    public int gold;
    public int[] unlockedItems;
    private string[] lines;
    private string[] linesUnlockedItems;
    public int masyvoDydis;

    //private string UpdateGoldURL = "http://localhost/do_or_die/UpdateGold.php";
    //private string UpdateUnlockedItemsURL = "http://localhost/do_or_die/UpdateUnlockedItems.php";
    private string UpdateGoldURL = "http://doordie.000webhostapp.com/do_or_die/UpdateGold.php";
    private string UpdateUnlockedItemsURL = "http://doordie.000webhostapp.com/do_or_die/UpdateUnlockedItems.php";

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
    }
    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void setValues()
    {
        lines = infoEilute.Split('|');
        playerName = lines[0].Trim();
        highscore = int.Parse(lines[1].Trim());
        gold = int.Parse(lines[2].Trim());
        masyvoDydis = int.Parse(lines[3].Trim());
        unlockedItems = new int[masyvoDydis];
        linesUnlockedItems = lines[4].Trim().Split(',');
        for (int i = 0; i < masyvoDydis; i++)
        {
            unlockedItems[i] = int.Parse(linesUnlockedItems[i].Trim());
        }
    }
    public IEnumerator UpdateGold(string username, int gold)
    {
        WWWForm updateForma = new WWWForm();
        updateForma.AddField("usernamePost", username);
        updateForma.AddField("goldPost", gold);


        WWW www = new WWW(UpdateGoldURL, updateForma);
        yield return www;
        Debug.Log(www.text);
        //loadPlayerString = www.text;
        //yield return www.text;
    }
    public IEnumerator UpdateUnlockedItems(string username, int itemId)
    {
        WWWForm updateForma = new WWWForm();
        updateForma.AddField("usernamePost", username);
        updateForma.AddField("itemPost", itemId);


        WWW www = new WWW(UpdateUnlockedItemsURL, updateForma);
        yield return www;
        Debug.Log(www.text);
        //loadPlayerString = www.text;
        //yield return www.text;
    }
}
