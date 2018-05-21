using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameOverManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    public float restartDelay = 5f;

    Animator anim;
    float restartTimer;
    AudioSource zaidimoMuzika;

    //private string UpdateHighscoreURL = "http://localhost/do_or_die/UpdateHighscore.php";
    private string UpdateHighscoreURL = "http://doordie.000webhostapp.com/do_or_die/UpdateHighscore.php";
    private bool arJauNaujina = false;
    public TMP_Text newHighscoreText;
    public TMP_Text goldEarnedText;

    // Use this for initialization
    private void Awake()
    {
        anim = GetComponent<Animator>();
        zaidimoMuzika = GetComponent<AudioSource>();
    }

	
	// Update is called once per frame
	void Update ()
    {
		if(playerHealth.currentHealth<=0)
        {
            if(!arJauNaujina)
            StartCoroutine(EndGame());
            /*
            zaidimoMuzika.Stop();
            anim.SetTrigger("GameOver");
            GameObject zaidejoInfo = GameObject.Find("ZaidejoInformacija");
            if (ScoreManager.score>zaidejoInfo.GetComponent<LoadPlayerInfo>().highscore)
            {
                StartCoroutine(UpdateHighscore(zaidejoInfo.GetComponent<LoadPlayerInfo>().name,
                    zaidejoInfo.GetComponent<LoadPlayerInfo>().highscore));
                zaidejoInfo.GetComponent<LoadPlayerInfo>().highscore = ScoreManager.score;
            }
            */
            restartTimer = restartTimer + Time.deltaTime;
            
            if(restartTimer>=restartDelay)
            {
                SceneManager.LoadScene("Menu");
            }
            
        }
	}
    IEnumerator UpdateHighscore(string username, int highscore)
    {
        WWWForm updateForma = new WWWForm();
        updateForma.AddField("usernamePost", username);
        updateForma.AddField("highscorePost", highscore);


        WWW www = new WWW(UpdateHighscoreURL, updateForma);
        yield return www;
        Debug.Log(www.text);
        //loadPlayerString = www.text;
        //yield return www.text;
    }
    IEnumerator EndGame()
    {
        arJauNaujina = true;
        zaidimoMuzika.Stop();
        anim.SetTrigger("GameOver");
        GameObject zaidejoInfo = GameObject.Find("ZaidejoInformacija");
        
        if (ScoreManager.score > zaidejoInfo.GetComponent<LoadPlayerInfo>().highscore)
        {
            yield return StartCoroutine(UpdateHighscore(zaidejoInfo.GetComponent<LoadPlayerInfo>().playerName,
                ScoreManager.score));
            zaidejoInfo.GetComponent<LoadPlayerInfo>().highscore = ScoreManager.score;
            newHighscoreText.gameObject.SetActive(true);
        }
        int goldEarned = ScoreManager.score / 10;
        goldEarnedText.gameObject.SetActive(true);
        goldEarnedText.text = goldEarnedText.text + goldEarned.ToString() + " gold.";
        zaidejoInfo.GetComponent<LoadPlayerInfo>().gold += goldEarned;
        yield return StartCoroutine(zaidejoInfo.GetComponent<LoadPlayerInfo>().UpdateGold(
            zaidejoInfo.GetComponent<LoadPlayerInfo>().playerName, zaidejoInfo.GetComponent<LoadPlayerInfo>().gold));
    }
}
