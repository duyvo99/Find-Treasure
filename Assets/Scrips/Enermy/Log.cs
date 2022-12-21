using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.AI;


public class Log : EnermyAI
{
    private Rigidbody2D myRigidbody;

    public Transform target;

    public float chaseRadius;

    public float attackRadius;

    public Transform homePosition;


    public Animator anim;



    ////SET DAMAGE ENEMY
    private bool isCollider = false;
    float enemyDamage = 30;
    float spawnTime = 2;
    float m_spawnTime;
    public float enemyDamageAttack = 30;



    public GameObject player;



    ////ENEMY FIND PLAYER
    NavMeshAgent agent;



    ////VFX
    public GameObject objectVFXSecond;


    ////BUFF BOSS
    public GameObject buffBossVFX;




    // Start is called before the first frame update
    void Start()
    {
        currentState = EnermyState.idle;


        myRigidbody = GetComponent<Rigidbody2D>();

        

        target = GameObject.FindWithTag("Player").transform;


        anim = GetComponent<Animator>();



        player = GameObject.FindWithTag("Player");



        ////ENEMY FIND PLAYER
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;



        ////BUFF BOSS
        buffBossVFX.SetActive(false);

    }


    private void FixedUpdate()
    {
        CheckDistance();



        ////SET DAMAGE ENEMY
        //m_spawnTime -= Time.deltaTime;

        ////if (elapsed > regenDelay)
        //if (m_spawnTime <= 0)
        //{
            if (isCollider)
            {

                //PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().TakeDamagePlayer(enemyDamage);
            }

            m_spawnTime = spawnTime;
        //}

        //elapsed += Time.deltaTime;

        //else
        //{
        //    spawnTime = 2;
        //}
    }




    ////ANIMATION ATTACK
    private void Update()
    {


        


        if (Vector2.Distance(target.position, transform.position) <= attackRadius)
        {
            //anim.SetTrigger("attack");
            anim.SetBool("Attack", true);
        }

        else if(Vector2.Distance(target.position, transform.position) > attackRadius)
        {
            //anim.ResetTrigger("attack");
            anim.SetBool("Attack", false);
        }




        //if(EnemyHealth.FindObjectOfType<EnemyHealth>().currentHealth <= 190)
        //{

        //    if(objectVFXSecond)
        //    {
        //        //VFXBoss();

        //        buffBossVFX.SetActive(true);

        //    }    
            

        //    moveSpeed = 3.5f;



        //    //gameObject.transform.localScale();
        //}    




    }




    void CheckDistance()
    {

        Debug.Log("HAHAAA3");

        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            &&
            Vector3.Distance(target.position, transform.position) > attackRadius)
        {

            if (currentState == EnermyState.idle || currentState == EnermyState.walk && currentState != EnermyState.stagger)
            {


                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);


                changeAnim(temp - transform.position);

                myRigidbody.MovePosition(temp);





                ////KO BỊ ĐẨY ISKINEMATIC = FALSE////



              
                ////ENEMY FIND PLAYER
                //agent.SetDestination(target.position);




                ChangeState(EnermyState.walk);


                anim.SetBool("wakeUp", true);

            }



        }



        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            //anim.SetBool("wakeUp", false);


            if (currentState == EnermyState.idle || currentState == EnermyState.walk && currentState != EnermyState.stagger)
            {
                ////QUAY LẠI ĐIỂM BAN ĐẦU
                Vector3 temp2 = Vector3.MoveTowards(transform.position, homePosition.position, moveSpeed * Time.deltaTime);


                changeAnim(temp2 - transform.position);


                myRigidbody.MovePosition(temp2);



                ChangeState(EnermyState.walk);


                anim.SetBool("wakeUp", true);
            }



            //anim.SetBool("wakeUp", true);


        }

        if (transform.position == homePosition.position)
        {
            anim.SetBool("wakeUp", false);
        }




    }


    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);

        anim.SetFloat("moveY", setVector.y);
    }


    private void changeAnim(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }

            else if(direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }

        else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }

            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }    


    private void ChangeState(EnermyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }




    ////SET DAMAGE ENEMY 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //isCollider = true;
        }  
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            //isCollider = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollider = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isCollider = false;

        }    
    }


    public void AttackHaha()
    {
        if(isCollider)
        {
            PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().TakeDamagePlayer(enemyDamageAttack);
        }    
    }    


    public void VFXBoss()
    {
        Instantiate(objectVFXSecond, transform.position, Quaternion.identity);
    }    

}
