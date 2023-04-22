using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using UnityEngine.UI;
using System.IO;
using TMPro;

public class Register_Thay : Singleton<Register_Thay>
{

    //public InputField userName;

    //public InputField passWord;
    public TMP_InputField userName;
    public TMP_InputField passWord;


    public Text userNameText;

    public Text passWordText;

    public GameObject successfullText;


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

    public void Registering()
    {
        WriteCSV();
    }    


    // Start is called before the first frame update
    void Start()
    {
        /////
        fileWriter = Path.Combine(Application.streamingAssetsPath, "test1.csv");




        ReadCSV();
    }


    void ReadCSV()
    {
        //TextReader tr = new StreamReader(Application.dataPath + "/test1.csv", true);
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


    void WriteCSV()
    {
        //TextWriter tw = new StreamWriter(Application.dataPath + "D:/FindTreasure/Assets/StreamingAssets/test1.csv", true);
        TextWriter tw = new StreamWriter(fileWriter, true);
        //TextWriter tw = new StreamWriter("C:/Unity/ProjectGameGreenAcademy(17_10_2022_/Assets/test1.csv", true);

        if (CheckUserExisted() == true && userList.users.Length != 0)
        {
            userNameText.text = "Error, Your userName was existed";

            tw.Close();
        }

        else
        {
            tw.WriteLine(userName.text + "," + passWord.text);

            tw.Close();

            successfullText.SetActive(true);
        }

        ReadCSV();

    }

    bool CheckUserExisted()
    {
        bool isExisted = false;

        for (int i = 0; i < userList.users.Length; i++)
        {
            if(userName.text == userList.users[i].user)
            {
                isExisted = true;

                break;
            }

            else
            {
                continue;
            }
        }

        return isExisted;
    }    


}
