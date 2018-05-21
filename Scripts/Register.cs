using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;
using TMPro;

public class Register : MonoBehaviour {
    public TMP_InputField username;
    public TMP_InputField email;
    public TMP_InputField password;
    public TMP_InputField confPassword;
    //public GameObject username;
    //public GameObject email;
    //public GameObject password;
    //public GameObject confPassword;
    private string Username;
    private string Email;
    private string Password;
    private string ConfPassword;
    private string form;
    //private string CreateUserURL = "http://localhost/do_or_die/InsertUser.php";
    //private string UsernameTakenURL = "http://localhost/do_or_die/UsernameTakenCheck.php";
    private string CreateUserURL = "http://doordie.000webhostapp.com/do_or_die/InsertUser.php";
    private string UsernameTakenURL = "http://doordie.000webhostapp.com/do_or_die/UsernameTakenCheck.php";
    private string testString="";
    private bool EmailValid=false;
    private string[] Characters ={"a","b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                  "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                                  "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "_", "-"};

	IEnumerator RegisterButton()
    {
        bool UN = false;
        bool EM = false;
        bool PW = false;
        bool CPW = false;

        if(Username!="")
        {
            yield return StartCoroutine(UsernameTakenCheck(Username));
            //StartCoroutine(UsernameTakenCheck(Username));
            
            //Debug.LogError("testStringas:" + testString);
            //if (!System.IO.File.Exists(@"C:/UnityTestFolder/" + Username + ".txt"))
            if (testString=="User not found.")
            {
                Debug.LogWarning("GREAT SUCCESS");
                UN = true;
            }
            else
            {
                Debug.LogWarning("Username taken.");
            }

        }
        else
        {
            Debug.LogWarning("Username field is empty.");
        }
        if (Email != "")
        {
            EmailValidation();
            if(EmailValid)
            {
                if(Email.Contains("@"))
                {
                    if (Email.Contains("."))
                    {
                        EM = true;
                    }
                }
                else
                {
                    Debug.LogWarning("Email is incorrect.");
                }
            }
            else
            {
                Debug.LogWarning("Email is incorrect.");
            }
        }
        else
        {
            Debug.LogWarning("Email field is empty.");
        }
        if (Password != "")
        {
            if(Password.Length>5)
            {
                PW = true;
            }
            else
            {
                Debug.LogWarning("Password must be atleast 6 characters long.");
            }
        }
        else
        {
            Debug.LogWarning("Password field is empty.");
        }
        if(ConfPassword!="")
        {
            if(ConfPassword==Password)
            {
                CPW = true;
            }
            else
            {
                Debug.LogWarning("Passwords don't match.");
            }
        }
        else
        {
            Debug.LogWarning("Confirm password field is empty.");
        }
        if (UN ==true&& EM ==true&& PW==true&& CPW==true)
        {
            /*
            bool Clear = true;
            int i = 1;
            foreach(char c in Password)
            {
                if (Clear)
                {
                    Password = "";
                    Clear = false;
                }
                i++;
                char Encrypted = (char)(c * i);
                Password += Encrypted.ToString();
            }
            */
            //form = (Username + Environment.NewLine + Email + Environment.NewLine + Password);
            //System.IO.File.WriteAllText(@"C:/UnityTestFolder/" + Username + ".txt", form);
            yield return StartCoroutine(CreateUser(Username, Email, Password));
            //Debug.LogError("USERNAME:" + Username + "PASSWORD" + Password + "EMAIL:" + Email);
            username.text="";
            email.text="";
            password.text="";
            confPassword.text="";
            print("Registration Successful.");
        }
    }
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.isFocused)
            {
                email.Select();
            }
            if (email.isFocused)
            {
                password.Select();
            }
            if (password.isFocused)
            {
                confPassword.Select();
            }
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (Password != "" && Email != "" && ConfPassword != "" && Username != "")
                StartCoroutine(RegisterButton());
        }
        Username = username.text;
        Email = email.text;
        Password = password.text;
        ConfPassword = confPassword.text;
    }

    void EmailValidation()
    {
        bool SW = false;
        bool EW = false;
        for(int i=0; i<Characters.Length; i++)
        {
            if (Email.StartsWith(Characters[i]))
            {
                SW = true;
            }
        }
        for (int i = 0; i < Characters.Length; i++)
        {
            if (Email.EndsWith(Characters[i]))
            {
                EW = true;
            }
        }
        if(SW==true&& EW==true)
        {
            EmailValid = true;
        }
        else
        {
            EmailValid = false;
        }
    }

    IEnumerator CreateUser(string username, string email, string password)
    {
        WWWForm forma = new WWWForm();
        forma.AddField("usernamePost", username);
        forma.AddField("emailPost", email);
        forma.AddField("passwordPost", password);

        WWW www = new WWW(CreateUserURL,forma);
        yield return www;
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
    public void StartCoroutineRegisterButton()
    {
        StartCoroutine(RegisterButton());
    }

}
