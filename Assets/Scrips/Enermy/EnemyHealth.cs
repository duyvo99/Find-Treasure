using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    private bool IsTrigger = false;


    public float maxHealth = 200f;

    public float currentHealth = 200f;


    public HealthBar healthBar;


    CharacterController2D player;


    int maxDamage = 30;


    ////VFX
    public GameObject objectVFX;


    ////SECOND VFX
    public GameObject objectVFXSecond;




    //public Vector3 attackOffset;
    //Log log;
    //public LayerMask attackMask;



    //new
    public GameObject winPanel;
    bool isDeadth = false;

    GameManager gameManager;
    float spawnTime = 1;
    float m_spawnTime = 1;





    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetMaxHealth(maxHealth);



        //log = GetComponent<Log>();



        ////new
        winPanel.SetActive(false);
        gameManager = GetComponent<GameManager>();
        //m_spawnTime = spawnTime;
        



    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space) && IsTrigger)
        {


        }


        if (currentHealth <= 0)
        {

            ////VFX
            if (objectVFX && objectVFXSecond)
            {
                Instantiate(objectVFX, transform.position, Quaternion.identity);

                //StartCoroutine(ScecondVFX());
                Instantiate(objectVFXSecond, transform.position, Quaternion.identity);
            }





            ////new
            //if (isDeadth)
            //{
            //    m_spawnTime -= Time.deltaTime;

            //    //if (elapsed > regenDelay)
            //    if (m_spawnTime <= 0)
            //    {
            //        winPanel.SetActive(true);

            //        //m_spawnTime = spawnTime;
            //    }
            //    //StartCoroutine(SceneWinPanel());
            //    //winPanel.SetActive(true);
            //}

            //StartCoroutine(SceneWinPanel(2f));
            //Invoke("SceneWinPanel", 2.0f);
            winPanel.SetActive(true);
            //gameManager.StartCoroutine(gameManager.SceneWinPanel());
            //RunIEnumerator();



            //Destroy(gameObject);
            gameObject.SetActive(false);






            ////Decrease health player when treasures are destroyed
            //PlayerTakeDamage.FindObjectOfType<PlayerTakeDamage>().TakeDamagePlayer(maxDamage);





            ////CHANGE SCENE
            //StartCoroutine(ChangeCutScene(1.5F));
            SceneManager.LoadScene("CutScene2BuffBoss");

             


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


    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }



    //public void Attack()
    //{
    //    Vector3 pos = transform.position;

    //    pos += transform.right * attackOffset.x;

    //    pos += transform.up * attackOffset.y;

    //    Collider2D colInfo = Physics2D.OverlapCircle(pos, log.attackRadius, attackMask);

    //    if(colInfo != null)
    //    {
    //        colInfo.GetComponent<PlayerTakeDamage>().TakeDamagePlayer(maxDamage);
    //    }    
    //}    




    ////CREATE NEW VFX
    IEnumerator ScecondVFX()
    {
        yield return new WaitForSeconds(2f);

        Instantiate(objectVFXSecond, transform.position, Quaternion.identity);
    }




    ////new
    //public void SceneWinPanel()
    //{



    //    winPanel.SetActive(true);

    //}

    IEnumerator SceneWinPanel(float delay)
    {

        yield return new WaitForSeconds(delay);
        //yield return null;

        winPanel.SetActive(true);



    }
    //public void RunIEnumerator()
    //{
    //    StartCoroutine(SceneWinPanel());
    //}


    public void SetIsDeadth()
    {
        if (currentHealth <= 0)
        {
            isDeadth = true;
        }

    }




    ////CHANGE SCENE 
    IEnumerator ChangeCutScene(float delay)
    {

        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene("CutScene2BuffBoss");



    }



}
