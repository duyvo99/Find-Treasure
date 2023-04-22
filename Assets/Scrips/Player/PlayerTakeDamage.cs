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





    ////ADD HEALTH AND MANA
    //HEALTH
    public GameObject addHealth;
    float countNumberHealth = 1;
    //VFX FOR HEALTH
    public GameObject vfxHealth;

    //MANA
    public GameObject addMana;
    float countNumberMana = 1;
    //VFX FOR MANA
    public GameObject vfxMana;



    ////VFX BLOOD
    public GameObject vfxBloodPlayer;







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






        ////ADD HEALTH AND MANA
        addHealth.SetActive(true);
        addMana.SetActive(true);






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
        if(m_spawnTime <= 0 && currentManaPlayer < maxManaPlayer)
        {
            currentManaPlayer = Mathf.Min(currentManaPlayer + regenRateMana, maxManaPlayer);
            //StartCoroutine(IncreateMana());

            m_spawnTime = spawnTime;
        }

        //elapsed += Time.deltaTime;

        else
        {
            spawnTime = 0.5f;
        }





        ////ADD HEALTH AND MANA
        //HEALTH
        if(Input.GetKeyDown(KeyCode.Keypad1) && countNumberHealth > 0 && addHealth)
        {
            currentHealthPlayer = currentHealthPlayer + 20;


            ////ADD HEALTH SOUND
            SoundMangagerScripts2.PlaySound("AddHealth");


            Instantiate(vfxHealth, gameObject.transform.position, Quaternion.identity);

            countNumberHealth--;

            addHealth.SetActive(false);

            if(currentHealthPlayer >= maxHealthPlayer)
            {
                currentHealthPlayer = maxHealthPlayer;
            }    
        }    

        else if(Input.GetKeyDown(KeyCode.Keypad2) && countNumberMana > 0 && addMana)
        {
            currentManaPlayer = currentManaPlayer + 20;


            ////ADD MANA SOUND
            SoundMangagerScripts2.PlaySound("AddMana");


            Instantiate(vfxMana, gameObject.transform.position, Quaternion.identity);

            countNumberMana--;

            addMana.SetActive(false);

            if(currentManaPlayer >= maxManaPlayer)
            {
                currentManaPlayer = maxManaPlayer;
            }    
        }    






    }


    ////HEALTH
    public void TakeDamagePlayer(float damagePlayer)
    {
        currentHealthPlayer -= damagePlayer;

        healthBarPlayer.SetHealth(currentHealthPlayer);



        ////VFX BLOOD PLAYER
        Instantiate(vfxBloodPlayer, transform.position, Quaternion.identity);

    }



    ////MANA
    public void TakeManaPlayer(float manaPlayer)
    {
        currentManaPlayer -= manaPlayer;

        manaBarPlayer.SetHealth(currentManaPlayer);
    }



}
