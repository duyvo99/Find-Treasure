using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHealth : MonoBehaviour
{

    private bool IsTrigger = false;


    public float maxHealth = 100f;
    
    public float currentHealth = 100f;


    public HealthBar healthBar;


    CharacterController2D player;


    public int minScore;

    public int maxScore;


    public int minDamage = 10;

    public int maxDamage = 30;



    [SerializeField] GameObject pickUpDropCoins;

    [SerializeField] int dropCount;

    [SerializeField] float spread;



    ////set attack Rate
    public float attackRate = 1f;
    float nextAttackTime = 0f;



    ////VFX
    public GameObject objectVFX;





    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);


    }

    // Update is called once per frame
    void Update()
    {


        ////set attack Rate
        //if(Time.time >= nextAttackTime)
        //{


            if (Input.GetKeyDown(KeyCode.Space) && IsTrigger)
            {

                //TakeDamage(CharacterController2D.Ins.damageMainCharacter);


                //nextAttackTime = Time.time + (1f / attackRate);
            }    
                



            



            if (currentHealth <= 0)
            {

                GameManager.Ins.AddScore(ScoreBonus);


                while (dropCount > 0)
                {
                    dropCount -= 1;

                    Vector3 postion = transform.position;

                    postion.x += spread * UnityEngine.Random.value - spread / 2;

                    postion.y += spread * UnityEngine.Random.value - spread / 2;

                    GameObject go = Instantiate(pickUpDropCoins);

                    go.transform.position = postion;
                }



                ////VFX
                if(objectVFX)
                {
                    Instantiate(objectVFX, transform.position, Quaternion.identity);
                }    




                Destroy(gameObject);



                ////Decrease health player when treasures are destroyed
                PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().TakeDamagePlayer(Random.Range(minDamage, maxDamage));




                ////CAMERA SHAKE (RUNG MÀNG HÌNH)
                CineController.Ins.ShakeTrigger();




                ////CHANGE SCENE TO LV2
                GameManager.Ins.DestroyTreasure();




                ////CREATE SOUND
                SoundMangagerScripts2.PlaySound("TreasureDestroySound");

                


            }

        //}    

       


       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsTrigger = false;
    }


    public int ScoreBonus
    {
        get => Random.Range(minScore, maxScore) * 1;
    }    



    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
