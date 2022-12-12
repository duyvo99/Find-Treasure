using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BuffChoices : Singleton<BuffChoices>
{

    public GameObject buffChoices;

    //float damagePlayer = 10;

    //public int number;




    ////REVIVAL PLAYER
    public GameObject revivalPlayerPanel;

    public GameObject player;


    ////THU NGHIEM
    public Button test;

    GameObject Testplayer;

    PlayerTakeDamage playerTakeDamage2;

    float TestmaxHealth;

    float TestmaxCurrentHealth;

    float TestmaxMana;

    float TestmaxCurrentMana;





    public override void Awake()
    {
        MakeSingleton(false);

    }

    private void Start()
    {
        //CharacterController2D.Ins.damageMainCharacter = damagePlayer;



        ////DAMAGE
        CharacterController2D.Ins.damageMainCharacter = PlayerPrefs.GetFloat("damage", CharacterController2D.Ins.damageMainCharacter);



        //GameManager.Ins.numberOfTreasure = PlayerPrefs.GetInt("treasures", GameManager.Ins.numberOfTreasure);



        ////HEALTH
        PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxHealthPlayer = 
            PlayerPrefs.GetFloat("Healths", PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxHealthPlayer);
        //TestmaxHealth =
        //    PlayerPrefs.GetFloat("Healths", TestmaxHealth);

        PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().currentHealthPlayer =
        PlayerPrefs.GetFloat("HealthCurrent", PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().currentHealthPlayer);
        //TestmaxCurrentHealth =
        //    PlayerPrefs.GetFloat("HealthCurrent", TestmaxCurrentHealth);



        ////HỒI MÁU
        CharacterController2D.FindObjectOfType<CharacterController2D>().Respawn();



        ////MANA
        PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxManaPlayer = 
            PlayerPrefs.GetFloat("Mana", PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxManaPlayer);

        PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().currentManaPlayer =
            PlayerPrefs.GetFloat("CurrentMana", PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().currentManaPlayer);



        ////ATTACK RATE
        CharacterController2D.Ins.attackRate = PlayerPrefs.GetFloat("AttackRate", CharacterController2D.Ins.attackRate);




        ////THU NGHIEM////
        ////MAX HEALTH TEST
        Testplayer = GameObject.FindWithTag("Player");
        playerTakeDamage2 = Testplayer.GetComponent<PlayerTakeDamage>();
        TestmaxHealth = playerTakeDamage2.maxHealthPlayer;

        ////CURRENT HEALTH TEST
        Testplayer = GameObject.FindWithTag("Player");
        playerTakeDamage2 = Testplayer.GetComponent<PlayerTakeDamage>();
        TestmaxCurrentHealth = playerTakeDamage2.currentHealthPlayer;

        ////MAX MANA TEST
        Testplayer = GameObject.FindWithTag("Player");
        playerTakeDamage2 = Testplayer.GetComponent<PlayerTakeDamage>();
        TestmaxMana = playerTakeDamage2.maxManaPlayer;

        ////CURRENT MANA TEST
        Testplayer = GameObject.FindWithTag("Player");
        playerTakeDamage2 = Testplayer.GetComponent<PlayerTakeDamage>();
        TestmaxCurrentMana = playerTakeDamage2.currentManaPlayer;

    }



    //////CHANGE SCENE TO LV2
    ////DAMAGE
    public void IncreateDamage()
    {


        SceneManager.LoadScene("Level2");



        //CharacterController2D.FindObjectOfType<CharacterController2D>().damageMainCharacter = 17.5f;
        //GameManager.Ins.numberOfTreasure = 8;




        buffChoices.SetActive(false);

        AddDamage();

        TestmaxCurrentMana = TestmaxMana;




        ////REVIVAL PLAYER
        player.SetActive(true);


        revivalPlayerPanel.SetActive(false);




        //CHANGE SCENE TO LV2
        //ddTreasure();

    }


    ////HEALTH
    public void IncreateHealth()
    {


        SceneManager.LoadScene("Level2");



        buffChoices.SetActive(false);


        //AddHealth();
        ////THU NGHIEM
        TestmaxHealth = (TestmaxHealth * 0.75f) + TestmaxHealth;

        TestmaxCurrentMana = TestmaxMana;



        ////REVIVAL PLAYER
        player.SetActive(true);


        revivalPlayerPanel.SetActive(false);

        //CHANGE SCENE TO LV2
        //AddTreasure();

    }


    ////MANA
    public void IncreateMana()
    {



        SceneManager.LoadScene("Level2");



        buffChoices.SetActive(false);


        //AddMana();
        ////THU NGHIEM
        TestmaxMana = (TestmaxMana * 0.75f) + TestmaxMana;

        TestmaxCurrentMana = TestmaxMana;



        ////REVIVAL PLAYER
        player.SetActive(true);


        revivalPlayerPanel.SetActive(false);


        //CHANGE SCENE TO LV2
        //AddTreasure();

    }



    ////REVIVAL PLAYER
    public void RevivalPlayerOkButton()
    {
        revivalPlayerPanel.SetActive(false);

        //Time.timeScale = 1f;
        player.SetActive(true);

        PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().currentHealthPlayer = 100;
        PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxHealthPlayer = 100;

        PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxManaPlayer = 200;


        ////HEALTH
        PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().healthBarPlayer.GetComponent<HealthBar>().slider.maxValue 
            = PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxHealthPlayer;

        //PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().healthBarPlayer.GetComponent<HealthBar>().slider.maxValue 
        //    = TestmaxHealth;


        PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().healthBarPlayer.GetComponent<HealthBar>().slider.value 
            = PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().currentHealthPlayer;

        //PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().healthBarPlayer.GetComponent<HealthBar>().slider.value
        //    = TestmaxCurrentHealth;



        ////MANA
        PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().manaBarPlayer.GetComponent<HealthBar>().slider.maxValue 
            = PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxManaPlayer;

        PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().manaBarPlayer.GetComponent<HealthBar>().slider.value 
            = PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().currentManaPlayer;
    }





    private void Update()
    {
        ////DAMAGE
        PlayerPrefs.SetFloat("damage", CharacterController2D.Ins.damageMainCharacter);



        ////CHANGE SCENE TO LV2
        //PlayerPrefs.SetInt("treasures", GameManager.Ins.numberOfTreasure);



        ////HEALTH
        //PlayerPrefs.SetFloat("Healths", PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxHealthPlayer);
        PlayerPrefs.SetFloat("Healths", TestmaxHealth);


        //PlayerPrefs.SetFloat("HealthCurrent", PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().currentHealthPlayer);
        PlayerPrefs.SetFloat("HealthCurrent", TestmaxCurrentHealth);



        ////MANA
        //PlayerPrefs.SetFloat("Mana", PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxManaPlayer);
        PlayerPrefs.SetFloat("Mana", TestmaxMana);

        //PlayerPrefs.SetFloat("CurrentMana", PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().currentManaPlayer);
        PlayerPrefs.SetFloat("CurrentMana", TestmaxCurrentMana);



        ////ATTACK RATE
        PlayerPrefs.SetFloat("AttackRate", CharacterController2D.Ins.attackRate);





        //////THU NGHIEM
        ////MAX HEALTH TEST
        //Testplayer = GameObject.FindWithTag("Player");
        //playerTakeDamage2 = Testplayer.GetComponent<PlayerTakeDamage>();
        //TestmaxHealth = playerTakeDamage2.maxHealthPlayer;

        ////CURRENT HEALTH TEST
        //Testplayer = GameObject.FindWithTag("Player");
        //playerTakeDamage2 = Testplayer.GetComponent<PlayerTakeDamage>();
        TestmaxCurrentHealth = playerTakeDamage2.currentHealthPlayer;

        ////MAX MANA TEST
        //Testplayer = GameObject.FindWithTag("Player");
        //playerTakeDamage2 = Testplayer.GetComponent<PlayerTakeDamage>();
        TestmaxMana = playerTakeDamage2.maxManaPlayer;

        ////CURRENT MANA TEST
        //Testplayer = GameObject.FindWithTag("Player");
        //playerTakeDamage2 = Testplayer.GetComponent<PlayerTakeDamage>();
        TestmaxCurrentMana = playerTakeDamage2.currentManaPlayer;


        ////REVIVAL PLAYER
        //if (PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().currentHealthPlayer <= 0)
        if (TestmaxCurrentHealth <= 0)
        {

            //Time.timeScale = 0f;
            player.SetActive(false);

            
            revivalPlayerPanel.SetActive(true);

            
            
        }



        //////THU NGHIEM
        //if(test.onClick.AddListener(RevivalPlayerOkButton())
        //{
            
        //}

    }



    //////CHANGE SCENE TO LV2/////
    ////DAMAGE
    public void AddDamage()
    {
        CharacterController2D.Ins.damageMainCharacter = (CharacterController2D.Ins.damageMainCharacter * 0.75f) + CharacterController2D.Ins.damageMainCharacter;
    }



    ////HEALTH
    public void AddHealth()
    {
        //PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxHealthPlayer =
        //    (PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxHealthPlayer * 0.75f) +
        //    PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxHealthPlayer;

        TestmaxHealth = (TestmaxHealth * 0.75f) + TestmaxHealth;


    }



    ////MANA
    public void AddMana()
    {
        //PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxManaPlayer =
        //    (PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxManaPlayer * 0.75f) +
        //    PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxManaPlayer;

        TestmaxMana = (TestmaxMana * 0.75f) + TestmaxMana;
    }    


    
    //public void AddTreasure()
    //{
        //GameManager.Ins.numberOfTreasure = GameManager.Ins.numberOfTreasure + 8;
    //}






    //////CHANGE SCENE TO LV3//////  ///////////////////////////////////////////////////////
    ////DAMAGE SECOND
    public void IncreateDamageSecond()
    {


        SceneManager.LoadScene("Level3");



        buffChoices.SetActive(false);

        //AddDamageSecond();
        CharacterController2D.Ins.damageMainCharacter = (CharacterController2D.Ins.damageMainCharacter * 1.25f) + CharacterController2D.Ins.damageMainCharacter;

        TestmaxCurrentMana = TestmaxMana;




        //CHANGE SCENE TO LV2
        //AddTreasure();

    }
    public void AddDamageSecond()
    {
        CharacterController2D.Ins.damageMainCharacter = (CharacterController2D.Ins.damageMainCharacter * 1.25f) + CharacterController2D.Ins.damageMainCharacter;
    }



    ////HEALTH SECOND
    public void IncreateHealthSecond()
    {


        SceneManager.LoadScene("Level3");




        //buffChoices.SetActive(false);

        //AddHealthSecond();
        TestmaxHealth = (TestmaxHealth * 1.25f) + TestmaxHealth;

        TestmaxCurrentMana = TestmaxMana;



        //CHANGE SCENE TO LV2
        //AddTreasure();

    }
    public void AddHealthSecond()
    {
        PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxHealthPlayer =
           (PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxHealthPlayer * 1.25f) +
           PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxHealthPlayer;
    }



    ////ATTACK RATE 
    public void IncreateAttackRate()
    {


        SceneManager.LoadScene("Level3");




        buffChoices.SetActive(false);

        AddAttackRate();

        TestmaxCurrentMana = TestmaxMana;




        //CHANGE SCENE TO LV2
        //AddTreasure();

    }
    public void AddAttackRate()
    {
        CharacterController2D.Ins.attackRate = CharacterController2D.Ins.attackRate + 2;
    }



}
