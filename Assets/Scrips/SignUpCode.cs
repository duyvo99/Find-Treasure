using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;


using System.IO;

public class SignUpCode : MonoBehaviour
{

    public InputField userName;

    public InputField passWord;

    public InputField phoneNumber;


    private string UserName;

    private string PassWord;

    private string PhoneNumber;


    public Text userNameText;

    public Text passWordText;

    public Text phoneNumberText;


    public GameObject successfullText;


    private string from;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UserName = userName.GetComponent<InputField>().text;

        PassWord = passWord.GetComponent<InputField>().text;

        PhoneNumber = phoneNumber.GetComponent<InputField>().text;

    }



    ////SAVE FILE EXCEL
    public void RegisterButton()
    {
        if (System.IO.File.Exists(@"C: /Unity/ProjectGameGreenAcademy(17_10_2022_)/" + "test.csv"));

    }




    public void RunCheckPass()
    {
        ////PASS WORD
        if (checkPassword(PassWord, 8))
        {
            passWordText.text = "Right Pass";
        }

        else
        {
            passWordText.text = "Wrong Pass";
        }



        ////USER NAME
        if (checkUserName(UserName, 8))
        {
            userNameText.text = "Right UserName";
        }

        else
        {
            userNameText.text = "Wrong UserName";
        }



        ////PHONE NUMBER
        if (checkPhoneNumber(PhoneNumber, 10))
        {
            phoneNumberText.text = "Right Phone";
        }

        else
        {
            phoneNumberText.text = "Wrong Phone";
        }



        if((checkUserName(UserName, 8)) && checkPassword(PassWord, 8) && checkPhoneNumber(PhoneNumber, 10))
        {
            successfullText.SetActive(true);
        }

        //else
        //{
        //    successfullText.SetActive(false);
        //}



        ////SAVE FROM
        from = (UserName + Environment.NewLine + PassWord);

        System.IO.File.WriteAllText(@"C:/Unity/ProjectGameGreenAcademy(17_10_2022_/test.csv", from);

        userName.GetComponent<InputField>().text = "";

        passWord.GetComponent<InputField>().text = "";

        phoneNumber.GetComponent<InputField>().text = "";

        print("Registration complete");

    }


    public void RunCheckUser()
    {
        //////USER NAME
        //if (checkUserName(UserName, 8))
        //{
        //    passWordText.text = "Right UserName";
        //}

        //else
        //{
        //    passWordText.text = "Wrong UserName";
        //}
    }


    ////PASS WORD
    public bool checkPassword(string input, int minimum)
    {

        string pass = passWord.text;

        bool hasNum = false;

        bool hasSpec = false;

        char currentCharacter;

        if(!(pass.Length >= minimum))
        {
            return false;
        }

        for (int i = 0; i < input.Length; i++)
        {
            currentCharacter = input[i];

            if(char.IsDigit(currentCharacter))
            {
                hasNum = true;
            }
      

            else if(!char.IsLetterOrDigit(currentCharacter))
            {
                hasSpec = true;
            }

            if(hasNum && hasSpec)
            {
                return true;
            }
        }

        return false;
    }


    ////USER NAME
    public bool checkUserName(string input, int minimum)
    {

        string user = userName.text;

        if (!(user.Length >= minimum))
        {
            return false;
        }

        return true;
    
    }


    ////PHONE NUMBER
    public bool checkPhoneNumber(string input, int minimum)
    {

        string phone = phoneNumber.text;

        char currentCharacter;

        if (!(phone.Length == minimum))
        {
            return false;
        }

        for (int i = 0; i < input.Length; i++)
        {
            currentCharacter = input[i];

            if (char.IsNumber(currentCharacter))
            {
                return true;
            }    
        }

        return false;
    }

}
