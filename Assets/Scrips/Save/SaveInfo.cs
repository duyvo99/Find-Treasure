using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInfo : MonoBehaviour
{

    public GameObject saveInfoPanel; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveInfoSceneOn()
    {

        saveInfoPanel.SetActive(true);

        Time.timeScale = 0f;
    }


    public void SaveInfoSceneOff()
    {
        saveInfoPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void ExitGamePlay()
    {
        Application.Quit();

        saveInfoPanel.SetActive(false);

        PlayerPrefs.DeleteAll();
    }    


}
