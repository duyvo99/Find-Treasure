using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private bool istrigger = false;
    //public GameObject collider;


    ////NEW 30/11
    GameObject Testplayer;
    CharacterController2D playerTakeDamage2;
    float TestmaxHealth;
    public ObjectHealth objectHealth;



    //Collider2D target;
    // Start is called before the first frame update
    void Start()
    {

        ////NEW 30/11
        Testplayer = GameObject.FindWithTag("Player");
        playerTakeDamage2 = Testplayer.GetComponent<CharacterController2D>();
        TestmaxHealth = playerTakeDamage2.damageMainCharacter;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && istrigger == true)
        {
            //ObjectHealth.FindObjectOfType<ObjectHealth>().TakeDamage(CharacterController2D.FindObjectOfType<CharacterController2D>().damageMainCharacter);


            ObjectHealth objectHealth;
            objectHealth = GetComponent<ObjectHealth>();
            objectHealth.TakeDamage(CharacterController2D.Ins.damageMainCharacter);
            //ObjectHealth.FindObjectOfType<ObjectHealth>().TakeDamage(TestmaxHealth);


            Debug.Log("2haaha");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "Object" )
        {

            istrigger = true;

            Debug.Log("haaha");
            //target = collision;

            //ObjectHealth objectHealth;
            //objectHealth = collision.gameObject.GetComponent<ObjectHealth>();
            //objectHealth.TakeDamage(CharacterController2D.FindObjectOfType<CharacterController2D>().damageMainCharacter);

            //ObjectHealth.FindObjectOfType<ObjectHealth>().TakeDamage(CharacterController2D.FindObjectOfType<CharacterController2D>().damageMainCharacter);
            
            ////AN CHI
            objectHealth = collision.GetComponent<ObjectHealth>();
            
            
            
            //if(this.enabled)
            //{

            //}

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Object"))
        {
            istrigger = false;

            Debug.Log("haahaaaaaaa");

            //ObjectHealth.FindObjectOfType<ObjectHealth>().TakeDamage(0);
            
            ////AN CHI
            objectHealth = collision.GetComponent<ObjectHealth>();

        }
    }


    public void DamageObject()
    {
        if (istrigger)
        {
            //ObjectHealth.FindObjectOfType<ObjectHealth>().TakeDamage(CharacterController2D.FindObjectOfType<CharacterController2D>().damageMainCharacter);


            ObjectHealth objectHealth;
            objectHealth = GetComponent<ObjectHealth>();
            //objectHealth.TakeDamage(CharacterController2D.FindObjectOfType<CharacterController2D>().damageMainCharacter);
        }
    }

}
