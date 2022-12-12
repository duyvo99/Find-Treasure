using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour 
{

    ////HEALTH
    public float maxHealthPlayer;

    public float currentHealthPlayer;


    public HealthBar healthBarPlayer;



    ////MANA
    public float maxManaPlayer = 200f;

    public float currentManaPlayer;


    public HealthBar manaBarPlayer;




    //////THU NGHIEM
    ////REVIVAL PLAYER
    public GameObject revivalPlayerPanel;

    public GameObject player;




    ////THU NGHIEM (22/11)

    float regenRateMana = 1f;
    float spawnTime = 2;
    float m_spawnTime;




    // Start is called before the first frame update
    void Start()
    {
        ////HEALTH
        currentHealthPlayer = maxHealthPlayer;

        healthBarPlayer.SetMaxHealth(maxHealthPlayer);



        ////MANA
        currentManaPlayer = maxManaPlayer;

        manaBarPlayer.SetMaxHealth(maxManaPlayer);




        ////THU NGHIEM (22/11)
        m_spawnTime = 0;

    }

    // Update is called once per frame
    void Update()
    {
        ////HEALTH
        healthBarPlayer.GetComponent<HealthBar>().slider.maxValue = maxHealthPlayer;

        healthBarPlayer.GetComponent<HealthBar>().slider.value = currentHealthPlayer;



        ////MANA
        manaBarPlayer.GetComponent<HealthBar>().slider.maxValue = maxManaPlayer;

        manaBarPlayer.GetComponent<HealthBar>().slider.value = currentManaPlayer;



        //////THU NGHIEM
        //////REVIVAL PLAYER
        //if (PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().currentHealthPlayer <= 0)
        ////if (currentHealthPlayer <= 0)
        //{

        //    //Time.timeScale = 0f;
        //    player.SetActive(false);


        //    revivalPlayerPanel.SetActive(true);



        //}

        //else
        //{
        //    //Time.timeScale = 0f;
        //    player.SetActive(true);


        //    revivalPlayerPanel.SetActive(false);
        //}




        ////THU NGHIEM (22/11)

        m_spawnTime -= Time.deltaTime;

        //if (elapsed > regenDelay)
        if(m_spawnTime <= 0 && currentHealthPlayer < maxManaPlayer)
        {
            currentManaPlayer = Mathf.Min(currentManaPlayer + regenRateMana, maxManaPlayer);
            //StartCoroutine(IncreateMana());

            m_spawnTime = spawnTime;
        }

        //elapsed += Time.deltaTime;

        else
        {
            spawnTime = 2;
        }


    }


    ////HEALTH
    public void TakeDamagePlayer(float damagePlayer)
    {
        currentHealthPlayer -= damagePlayer;

        healthBarPlayer.SetHealth(currentHealthPlayer);
    }



    ////MANA
    public void TakeManaPlayer(float manaPlayer)
    {
        currentManaPlayer -= manaPlayer;

        manaBarPlayer.SetHealth(currentManaPlayer);
    }



}
