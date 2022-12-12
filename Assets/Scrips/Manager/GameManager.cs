using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    int m_Score;


    public static GameManager instance;


    ////CHANGE SCENE TO LV2
    public int numberOfTreasure = 5;




    ////SCENE WIN PANELS
    public GameObject winPanel;
    GameObject TestEnemy;
    //EnemyHealth testEnemyHealth;
    float testEnemyHealthFloat;
    bool isDeadth;




    public override void Awake()
    {
        MakeSingleton(false);


        instance = this;

    }

    public override void Start()
    {
        GameGUIManager.Ins.UpdateScore(m_Score);





        ////NEW
        //TestEnemy = GameObject.FindWithTag("Enermy");
        ////testEnemyHealth = TestEnemy.GetComponent<EnemyHealth>();
        //testEnemyHealthFloat = TestEnemy.GetComponent<EnemyHealth>().currentHealth;




    }




    ////CHANGE SCENE TO LV2
    private void Update()
    {
        if(numberOfTreasure <= 0)
        {
            BuffChoices.Ins.buffChoices.SetActive(true);


            //Time.timeScale = 0f;

        }

        else
        {
            //Time.timeScale = 1f;
        }






        ////SCENE WIN PANELS
        //if (isDeadth)
        //{
        //    //StartCoroutine(SceneWinPanel());
        //    //Invoke("SceneWinPanel", 2f);
        //    winPanel.SetActive(true);

            
        //}



    }

    public void DestroyTreasure()
    {
        numberOfTreasure -= 1;
    }    






    public void AddScore(int scoreToAdd)
    {
        m_Score += scoreToAdd;

        GameGUIManager.Ins.UpdateScore(m_Score);
    }


    public GameObject player;






    ////SCENE WIN PANELS
    //public IEnumerator SceneWinPanel()
    //{

    //    yield return new WaitForSeconds(2f);

    //    winPanel.SetActive(true);

    //}
    public void SetIsDeadth()
    {
        if (EnemyHealth.FindObjectOfType<EnemyHealth>().currentHealth <= 0)
        {
            isDeadth = true;
            Debug.Log("haha");
        }

        
    }



    ////BACK SCENE
    public void BackSceneGame()
    {
        SceneManager.LoadScene("SceneGame");


        ////SCENE WIN PANELS
        winPanel.SetActive(false);
    }    



}
