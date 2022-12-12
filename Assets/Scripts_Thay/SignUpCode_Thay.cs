using System.Collections;
using System.Collections.Generic;

using UnityEngine;


using UnityEngine.UI;
using System.Text.RegularExpressions;
using TMPro;

public class SignUpCode_Thay : MonoBehaviour
{

    //public InputField userName;

    //public InputField passWord;

    //public InputField phoneNumber;
    public TMP_InputField userName;
    public TMP_InputField passWord;
    public TMP_InputField phoneNumber;


    public Text userNameText;

    public Text passWordText;

    public Text phoneNumberText;


    public Button createButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(userNameText.text == "Right User" && phoneNumberText.text == "Right Phone Number" && passWordText.text == "Right Password")
        {
            createButton.interactable = true;
        }

        else
        {
            createButton.interactable = false;
        }
    }


    public void CheckUserName()
    {
        if(userName.text.Length > 8)
        {
            userNameText.text = "Right User";
        }

        else
        {
            userNameText.text = "Wrong User";
        }
    }


    public void CheckPhoneNumber()
    {
        if (phoneNumber.text.Length == 10)
        {
            phoneNumberText.text = "Right Phone Number";
        }

        else
        {
            phoneNumberText.text = "Wrong Phone Number";
        }
    }


    public void CheckPassWord()
    {

        var hasNum = new Regex(@"[0-9]+");

        var hasSymbols = new Regex(@"[!@#$%^&*()_+-=[|{}\];:<>?,.]");

        var hasMinChars = new Regex(@".{8,15}");

        if(hasNum.IsMatch(passWord.text) && hasSymbols.IsMatch(passWord.text) && hasMinChars.IsMatch(passWord.text))
        {
            passWordText.text = "Right Password";
        }

        else
        {
            passWordText.text = "Wrong Password";
        }

    }
}
