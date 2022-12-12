using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

using UnityEngine.UI;
using System.IO;

public class SaveScore : MonoBehaviour
{
    public TMP_InputField userName;

    public Text scoreText;


    public UserList userList = new UserList();


    [System.Serializable]
    public class User
    {
        public string user;

        public string score;
    }

    [System.Serializable]
    public class UserList
    {
        public User[] users;
    }


    // Start is called before the first frame update
    void Start()
    {
        //userName.text = SignIn_Thay.Ins.userName.text;

        ReadCSV();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Playing()
    {
        WriteCSV();
    }


    void ReadCSV()
    {
        TextReader tr = new StreamReader(Application.dataPath + "/test2.csv", true);
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

                userList.users[i].score = data[2 * i + 1];
            }
        }

        tr.Close();
    }


    void WriteCSV()
    {
        TextWriter tw = new StreamWriter(Application.dataPath + "/test2.csv", true);
        //TextWriter tw = new StreamWriter("C:/Unity/ProjectGameGreenAcademy(17_10_2022_/Assets/test1.csv", true);

        if (CheckUserExisted() == true && userList.users.Length != 0)
        {
            tw.Write(scoreText.text);

            tw.Close();
        }

        else
        {
            tw.WriteLine(userName.text + "," + scoreText.text);

            tw.Close();
        }

        ReadCSV();

    }


    bool CheckUserExisted()
    {
        bool isExisted = false;

        for (int i = 0; i < userList.users.Length; i++)
        {
            if (userName.text == userList.users[i].user)
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
