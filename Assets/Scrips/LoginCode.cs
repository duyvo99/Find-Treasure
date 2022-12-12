using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;
using System.Text.RegularExpressions;


using System.IO;
using UnityEngine.SceneManagement;

public class LoginCode : MonoBehaviour
{
    public InputField userName;

    public InputField passWord;


    private string UserName;

    private string PassWord;



    public Text userNameText;

    public Text passWordText;



    private string from;


    private string[] Lines;


    private string DecryptedPass;


    // Start is called before the first frame update
    void Start()
    {

    }


    public void LoginButton()
    {
        bool UN = false;

        bool PW = false;


        ////USER NAME
        if(UserName != "")
        {
            if (System.IO.File.Exists(@"C:/Unity/ProjectGameGreenAcademy(17_10_2022_/test.csv"))
            {
                UN = true;

                Lines = System.IO.File.ReadAllLines(@"C:/Unity/ProjectGameGreenAcademy(17_10_2022_/test.csv");
            }

            else
            {
                userNameText.text = "Username doesn't exist";
            }
        }

        else
        {
            userNameText.text = "Username Empty";
        }


        ////PASSWORD
        if(PassWord != "")
        {

            if(System.IO.File.Exists(@"C:/Unity/ProjectGameGreenAcademy(17_10_2022_/test.csv"))
            {

                int i = 1;

                foreach (char c in Lines[1])
                {
                    i++;

                    char Decrypted = (char)(c / i);

                    DecryptedPass += Decrypted.ToString();
                }

                if(PassWord == DecryptedPass)
                {
                    PW = true;
                }

                else
                {
                    passWordText.text = "Your password is incorrect. Please try again";
                }
            }

            else
            {
                passWordText.text = "Your password is incorrect. Please try again";
            }
        }

        else
        {
            passWordText.text = "PassWord Empty";
        }

        if(UN == true && PW == true)
        {
            userName.GetComponent<InputField>().text = "";

            passWord.GetComponent<InputField>().text = "";

            SceneManager.LoadScene(1);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(userName.GetComponent<InputField>().isFocused)
            {
                passWord.GetComponent<InputField>().Select();
            }
        }

        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(UserName != "" && PassWord != "")
            {
                LoginButton();
            }
        }


        UserName = userName.GetComponent<InputField>().text;

        PassWord = passWord.GetComponent<InputField>().text;

      

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



        if ((checkUserName(UserName, 8)) && checkPassword(PassWord, 8))
        {
           
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

        bool hasLow = false;

        bool hasCap = false;

        bool hasSpec = false;

        char currentCharacter;

        if (!(pass.Length >= minimum))
        {
            return false;
        }

        for (int i = 0; i < input.Length; i++)
        {
            currentCharacter = input[i];

            if (char.IsDigit(currentCharacter))
            {
                hasNum = true;
            }


            else if (!char.IsLetterOrDigit(currentCharacter))
            {
                hasSpec = true;
            }

            if (hasNum && hasSpec)
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

   
}
