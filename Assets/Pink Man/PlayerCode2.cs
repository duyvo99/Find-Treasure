using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCode2 : MonoBehaviour
{
    private Rigidbody2D m_rb;

    public float speed;

    public float jump;

    private Animator anim;

    bool isGround;

    SpriteRenderer flipX;



    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        flipX = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");

        transform.position = transform.position + Vector3.right * dirX * speed * Time.deltaTime;

        if (dirX > 0f)
        {
            //state = MovementState.running;

            anim.SetBool("Running", true);

            flipX.flipX = false;

        }

        else if (dirX < 0f)
        {
            //state = MovementState.running;

            anim.SetBool("Running", true);

            flipX.flipX = true;
        }

        else
        {
            //state = MovementState.idle;

            anim.SetBool("Running", false);
        }



        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            anim.SetBool("Jumping", true);

            m_rb.velocity = new Vector2(m_rb.velocity.x, jump);


            isGround = false;
        }

        if(m_rb.velocity.y < -0.1f)
        {
            anim.SetBool("Falling", true);
        }

        else
        {
            anim.SetBool("Falling", false);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;

            anim.SetBool("Jumping", false);
        }

    }
}
