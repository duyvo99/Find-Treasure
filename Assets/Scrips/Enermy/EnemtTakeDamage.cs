using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemtTakeDamage : MonoBehaviour
{

    private bool IsTrigger = false;

    Animator animator;

    public float attackRate = 2f;

    float nextAttackTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //animator.SetBool("Attack", false);

        if (Time.time >= nextAttackTime)
        {
            if (IsTrigger )
            {
                //StartCoroutine(AttackCo());
                animator.SetBool("Attack", true);





                nextAttackTime = Time.time + 1f / attackRate;



                ////DECREASE MANA
                PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().TakeManaPlayer(30);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsTrigger = false;
    }


}
