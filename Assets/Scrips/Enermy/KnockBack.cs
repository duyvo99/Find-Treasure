using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{

    public float thrust;

    public float knockTime;

    Rigidbody2D enermy;

    // Start is called before the first frame update
    void Start()
    {
        enermy = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HitBox"))
        {
            //enermy = collision.GetComponent<Rigidbody2D>();
        

            Vector2 difference = transform.position - enermy.transform.position;

            difference = difference.normalized * thrust;

            enermy.AddForce(difference, ForceMode2D.Impulse);

            StartCoroutine(KnockCo(enermy));
            
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enermy)
    {
        if(enermy != null)
        {
            yield return new WaitForSeconds(knockTime);

            enermy.velocity = Vector2.zero;

        }
    }

}
