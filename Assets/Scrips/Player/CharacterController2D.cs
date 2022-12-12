using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : Singleton<CharacterController2D>
{

    Rigidbody2D m_rb;

    [SerializeField] float speed;


    Vector2 motionVector;
    
    public Vector2 lastMotionVector;


    Animator animator;

    public bool moving;


    public float damageMainCharacter = 10;



    ////set attack rate
    public float attackRate = 2f;

    float nextAttackTime = 0f;





    ////NEW ATTACK
    public Transform attackPoint;
    public Transform attackPointRight;
    public Transform attackPointUp;
    public Transform attackPointDown;
    public Transform attackPointBoss;
    public Transform attackPointBossRight;
    public Transform attackPointBossUp;
    public Transform attackPointBossDown;
    public float attackRange = 0.5f;
    public LayerMask enenyLayer;


    public LayerMask bossLayer;






    ////THU NGHIEM
    ////THU NGHIEM

    GameObject Testplayer;

    PlayerTakeDamage playerTakeDamage2;

    float TestmaxHealth;

    float TestmaxCurrentHealth;

    float TestmaxMana;


    // Start is called before the first frame update
    void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();




    }






    private void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");

        float vertical = Input.GetAxisRaw("Vertical");

        motionVector = new Vector2(horizontal, vertical);


        animator.SetFloat("horizontal", horizontal);

        animator.SetFloat("vertical", vertical);


        moving = horizontal != 0 || vertical != 0;

        animator.SetBool("moving", moving);




        ////set attack rate
        if(Time.time >= nextAttackTime && PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().currentManaPlayer >= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space) && moving == false)
            {
                //StartCoroutine(AttackCo());
                animator.SetTrigger("attack");





                ////NEW ATTACK
                //////////////// 28/11 ////////////
                if(lastMotionVector.x == -1 && lastMotionVector.y == 0)
                {
                    AttackLeft();
                    AttackLeftBoss();
                }
                else if(lastMotionVector.x == 1 && lastMotionVector.y == 0)
                {
                    AttackRight();
                    AttackRightBoss();
                }
                else if (lastMotionVector.x == 0 && lastMotionVector.y == -1)
                {
                    AttackDown();
                    AttackDownBoss();
                }
                else if (lastMotionVector.x == 0 && lastMotionVector.y == 1)
                {
                    AttackUp();
                    AttackUpBoss();
                }            




                nextAttackTime = Time.time + 1f / attackRate;



                ////DECREASE MANA
                PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().TakeManaPlayer(3);
            }
        }    

       
    
       
           

        if (horizontal != 0 || vertical != 0)
        {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;


            animator.SetFloat("lastHorizontal", horizontal);

            animator.SetFloat("lastVertical", vertical);

        }






        //PlayerPrefs.SetFloat("damage1", CharacterController2D.Ins.damageMainCharacter);





    }

    //private IEnumerator AttackCo()
    //{


    //    animator.SetBool("attacking", true);

    //    yield return null;

    //    animator.SetBool("attacking", false);

    //    yield return new WaitForSeconds(1f);

    //}


    // Update is called once per frame
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        m_rb.velocity = motionVector * speed;
    }



        ////NEW ATTACK
        void AttackLeft()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enenyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<ObjectHealth>().TakeDamage(damageMainCharacter);



            ////ADD NEW (24/11)
            //enemy.GetComponent<EnemyHealth>().TakeDamage(damageMainCharacter);
            //enemy.GetComponent<EnemyHealth>().TakeDamage(damageMainCharacter);
        }    
    }
    void AttackLeftBoss()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointBoss.position, attackRange, bossLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            //enemy.GetComponent<ObjectHealth>().TakeDamage(damageMainCharacter);



            ////ADD NEW (24/11)
            //enemy.GetComponent<EnemyHealth>().TakeDamage(damageMainCharacter);
            enemy.GetComponent<EnemyHealth>().TakeDamage(damageMainCharacter / 2);
        }
    }



    void AttackRight()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointRight.position, attackRange, enenyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<ObjectHealth>().TakeDamage(damageMainCharacter);



            ////ADD NEW (24/11)
            //enemy.GetComponent<EnemyHealth>().TakeDamage(damageMainCharacter);
            //enemy.GetComponent<EnemyHealth>().TakeDamage(damageMainCharacter);
        }
    }
    void AttackRightBoss()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointBossRight.position, attackRange, bossLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            //enemy.GetComponent<ObjectHealth>().TakeDamage(damageMainCharacter);



            ////ADD NEW (24/11)
            //enemy.GetComponent<EnemyHealth>().TakeDamage(damageMainCharacter);
            enemy.GetComponent<EnemyHealth>().TakeDamage(damageMainCharacter / 2);
        }
    }


    void AttackDown()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointDown.position, attackRange, enenyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<ObjectHealth>().TakeDamage(damageMainCharacter);



            ////ADD NEW (24/11)
            //enemy.GetComponent<EnemyHealth>().TakeDamage(damageMainCharacter);
            //enemy.GetComponent<EnemyHealth>().TakeDamage(damageMainCharacter);
        }
    }
    void AttackDownBoss()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointBossDown.position, attackRange, bossLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            //enemy.GetComponent<ObjectHealth>().TakeDamage(damageMainCharacter);



            ////ADD NEW (24/11)
            //enemy.GetComponent<EnemyHealth>().TakeDamage(damageMainCharacter);
            enemy.GetComponent<EnemyHealth>().TakeDamage(damageMainCharacter / 2);
        }
    }

    void AttackUp()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointUp.position, attackRange, enenyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<ObjectHealth>().TakeDamage(damageMainCharacter);



            ////ADD NEW (24/11)
            //enemy.GetComponent<EnemyHealth>().TakeDamage(damageMainCharacter);
            //enemy.GetComponent<EnemyHealth>().TakeDamage(damageMainCharacter);
        }
    }
    void AttackUpBoss()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointBossUp.position, attackRange, bossLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            //enemy.GetComponent<ObjectHealth>().TakeDamage(damageMainCharacter);



            ////ADD NEW (24/11)
            //enemy.GetComponent<EnemyHealth>().TakeDamage(damageMainCharacter);
            enemy.GetComponent<EnemyHealth>().TakeDamage(damageMainCharacter / 2);
        }
    }


    ////New


    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }    

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

        Gizmos.DrawWireSphere(attackPointRight.position, attackRange);

        Gizmos.DrawWireSphere(attackPointDown.position, attackRange);

        Gizmos.DrawWireSphere(attackPointUp.position, attackRange);
    }



    ////REVIVAL PLAYER
    public void Respawn()
    {
        PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().currentHealthPlayer = PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().maxHealthPlayer;
        //TestmaxCurrentHealth = TestmaxHealth;
    }


    ////THU NGHIEM
    //private void Start()
    //{
    //    ////MAX HEALTH TEST
    //    Testplayer = GameObject.FindWithTag("Player");
    //    playerTakeDamage2 = Testplayer.GetComponent<PlayerTakeDamage>();
    //    TestmaxHealth = playerTakeDamage2.maxHealthPlayer;

    //    ////CURRENT HEALTH TEST
    //    Testplayer = GameObject.FindWithTag("Player");
    //    playerTakeDamage2 = Testplayer.GetComponent<PlayerTakeDamage>();
    //    TestmaxCurrentHealth = playerTakeDamage2.currentHealthPlayer;
    //}




    ////NEW
    private bool isCollider = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enermy"))
        {
            isCollider = true;
        }


    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enermy"))
        {
            isCollider = false;
        }


    }

    public void AttackBoss()
    {
        if (isCollider)
        {
            //EnemyHealth.FindObjectOfType<EnemyHealth>().TakeDamage(damageMainCharacter);
        }
    }



}
