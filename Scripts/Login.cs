using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour {
    public TMP_InputField username;
    public TMP_InputField password;
    public GameObject zaidejoInformacija;
    private string Username;
    private string Password;
    //private string[] Lines;

    private string LoginURL = "http://doordie.000webhostapp.com/do_or_die/Login.php";
    private string UsernameTakenURL = "http://doordie.000webhostapp.com/do_or_die/UsernameTakenCheck.php";
    private string LoadPlayerInfoURL = "http://doordie.000webhostapp.com/do_or_die/GetPlayerInfo.php";
    //private string LoginURL = "http://localhost/do_or_die/Login.php";
    //private string UsernameTakenURL = "http://localhost/do_or_die/UsernameTakenCheck.php";
    //private string LoadPlayerInfoURL = "http://localhost/do_or_die/GetPlayerInfo.php";
    private string testString = "";
    private string loginString = "";
    private string loadPlayerString = "";

    IEnumerator LoginButton()
    {
        bool UN = false;
        bool PW = false;

        if(Username!="")
        {
            yield return StartCoroutine(UsernameTakenCheck(Username));
            Debug.LogError("testStringas:" + testString);
            //if (System.IO.File.Exists(@"C:/UnityTestFolder/" + Username + ".txt"))
            if (testString == "User found.")
            {
                UN = true;
                //Lines = System.IO.File.ReadAllLines(@"C:/UnityTestFolder/" + Username + ".txt");
            }
   
            else
            {
                Debug.LogWarning("Username invalid.");
            }
        }
        else
        {
            Debug.LogWarning("Username field is empty.");
        }
        if(Password!="")
        {
            //if (System.IO.File.Exists(@"C:/UnityTestFolder/" + Username + ".txt"))
            if (testString == "User found.")
            {
                yield return StartCoroutine(LoginToDB(Username, Password));
                //Debug.LogError("loginStringas:" + loginString);
                //if (Password == Lines[2])
                if(loginString== "Login success")
                    PW = true;
                else
                {
                    Debug.LogWarning("Password is incorrect.");
                }
            }
            else
            {
                Debug.LogWarning("Username is incorrect.");
            }
        }
        else
        {
            Debug.LogWarning("Password field is empty.");
        }
        if(UN==true&& PW==true)
        {
            username.text = "";
            password.text = "";
            yield return StartCoroutine(LoadPlayerInfo(Username));
            zaidejoInformacija.GetComponent<LoadPlayerInfo>().infoEilute = loadPlayerString;
            zaidejoInformacija.GetComponent<LoadPlayerInfo>().setValues();
            print("Login succesful");
            SceneManager.LoadScene("Menu");
        }
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.isFocused)
            {
                password.Select();
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Password != "" && Username != "")
                StartCoroutine(LoginButton());
        }
        Username = username.text;
        Password = password.text;
    }

    IEnumerator LoginToDB(string username, string password)
    {
        WWWForm loginForma = new WWWForm();
        loginForma.AddField("usernamePost", username);
        loginForma.AddField("passwordPost", password);

        WWW www = new WWW(LoginURL, loginForma);
        yield return www;
        Debug.Log(www.text);
        loginString = www.text;
        //yield return www.text;
    }
    IEnumerator UsernameTakenCheck(string username)
    {
        WWWForm usernameTakenForma = new WWWForm();
        usernameTakenForma.AddField("usernamePost", username);

        WWW www = new WWW(UsernameTakenURL, usernameTakenForma);
        yield return www;

        //yield return www.text;
        testString = www.text;
        Debug.Log(www.text);

    }

    public void StartCoroutineLoginButton()
    {
        StartCoroutine(LoginButton());
    }
    IEnumerator LoadPlayerInfo(string username)
    {
        WWWForm loadForma = new WWWForm();
        loadForma.AddField("usernamePost", username);
        

        WWW www = new WWW(LoadPlayerInfoURL, loadForma);
        yield return www;
        Debug.Log(www.text);
        loadPlayerString = www.text;
        //yield return www.text;
    }
}
