using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{

    public InputField userName;

    public InputField passWord;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckInfo()
    {
        string user = userName.text;

        string pass = passWord.text;

        if (user == "Duy" && pass == "123")
        {
            ChangeScenePlay();
        }

        else
        {
            Debug.Log("Wrong pass or userName");
        }
    }    

    public void ChangeScenePlay()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeSceneSignUp()
    {
        SceneManager.LoadScene("SignUpScene");
    }

    public void ChangeSceneMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ChangeCutScene1()
    {
        SceneManager.LoadScene("CutScene");



        ////TAT NHAC O SCENE MAIN MENU
        SoundVolumeMainMenu.FindObjectOfType<SoundVolumeMainMenu>().volumeSlider.value = 0;
        


    }

    public void ChangeSceneSettingVolume()
    {
        SceneManager.LoadScene("SceneSettingVolume");



        ////TAT NHAC O SCENE MAIN MENU
        SoundVolumeMainMenu.FindObjectOfType<SoundVolumeMainMenu>().volumeSlider.value = 0.5f;



    }



    public void ChangeScenePlayingGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }




}
