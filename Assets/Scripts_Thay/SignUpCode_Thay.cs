using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using System.Linq;


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
    bool checkUserName = false;

    public Text passWordText;
    bool checkPassWork = false;

    public Text phoneNumberText;
    bool checkPhoneNumber = false;


    public Button createButton;

    // Start is called before the first frame update
    void Start()
    {
        checkUserName = false;
        checkPassWork = false;
        checkPhoneNumber = false;

    }

    // Update is called once per frame
    void Update()
    {
        //if(userNameText.text == "Right User" && phoneNumberText.text == "Right Phone Number" && passWordText.text == "Right Password")
        if (checkPassWork && checkPhoneNumber && checkUserName)
        {
            createButton.interactable = true;

            Debug.Log("123000");
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
            checkUserName = true;
        }

        else
        {
            userNameText.text = "Wrong User";
            checkUserName = false;
        }
    }


    public void CheckPhoneNumber()
    {
        if (phoneNumber.text.Length == 10)
        {
            phoneNumberText.text = "Right Phone Number";
            checkPhoneNumber = true;
        }

        else
        {
            phoneNumberText.text = "Wrong Phone Number";
            checkPhoneNumber = false;
        }
    }


    public void CheckPassWord()
    {
        string passWordTextField = passWord.text;

        var hasNum = new Regex(@"[0-9]+");

        var hasSymbols = new Regex(@"[!@#$%^&*()_+-=[|{}\];:<>?,.]");

        var hasMinChars = new Regex(@".{8,15}");

        if(hasNum.IsMatch(passWord.text) && hasSymbols.IsMatch(passWord.text) && hasMinChars.IsMatch(passWord.text) && passWordTextField.Any(char.IsLetter) && passWordTextField.Any(char.IsUpper))
        {
            passWordText.text = "Right Password";
            checkPassWork = true;
        }

        else
        {
            passWordText.text = "Wrong Password";
            checkPassWork = false;
        }

    }
}
