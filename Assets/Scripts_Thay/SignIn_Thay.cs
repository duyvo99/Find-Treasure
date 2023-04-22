using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignIn_Thay : MonoBehaviour
{

    //public InputField userName;

    //public InputField passWord;
    public TMP_InputField userName;
    public TMP_InputField passWord;


    public Text userNameText;

    public Text passWordText;


    public TextAsset csv;

    public UserList userList = new UserList();



    string fileWriter = "";




    [System.Serializable]
    public class User
    {
        public string user;

        public string pass;


    }


    [System.Serializable]
    public class UserList
    {
        public User[] users;
    }


    // Start is called before the first frame update
    private void Start()
    {

        //////
        fileWriter = Path.Combine(Application.streamingAssetsPath, "test1.csv");


        ReadCSV();
    }


    void ReadCSV()
    {
        //TextReader tr = new StreamReader(Application.dataPath + "D:/FindTreasure/Assets/StreamingAssets/test1.csv", true);
        TextReader tr = new StreamReader(fileWriter, true);
        //TextReader tr = new StreamReader("C:/Unity/ProjectGameGreenAcademy(17_10_2022_/Assets/test1.csv", true);



        string[] data = tr.ReadToEnd().Split(',', '\n');

        int tablesize;

        Debug.Log(data.Length);

        tablesize = (data.Length - 1) / 2;

        userList.users = new User[tablesize];

        if (tablesize > 0)
        {
            for (int i = 0; i < tablesize; i++)
            {
                userList.users[i] = new User();

                userList.users[i].user = data[2 * i];

                userList.users[i].pass = data[2 * i + 1];
            }
        }

        tr.Close();
    }

    public void SignInFunc()
    {
        string name = userName.text;

        string pass = passWord.text;


        bool isAccount = false;

        bool isPass = false;

        for (int i = 0; i < userList.users.Length; i++)
        {


            ////TEST (25/11)
            string TestPass = userList.users[i].pass.Replace("\r", string.Empty);




            if (name == userList.users[i].user)
            {
                //if(pass == userList.users[i].pass)
                if (pass == TestPass)
                {
                    isAccount = true;

                    isPass = true;

                    break;
                }

                else
                {
                    isPass = false;

                    passWordText.text = "Wrong PassWord";

                }
            }

            else
            {
                isAccount = false;

                continue;
            }
        }

        if(isPass == true && isAccount == true)
        {
            SceneManager.LoadScene("SceneGame");
        }

        else
        {
            userNameText.text = "Error, Your userName isnot exsit";
        }
    }
}
