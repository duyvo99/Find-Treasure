using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCode : MonoBehaviour
{

    private Rigidbody2D m_rb;

    public float speed;

    public float jump;

    private Animator anim;

    bool isGround;


    private enum MovementState { idle, running, jumping, falling }

    MovementState state;



    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");

        transform.position = transform.position + Vector3.right * dirX * speed * Time.deltaTime;

        if(dirX > 0f)
        {
            state = MovementState.running;

        }

        else if(dirX < 0f)
        {
            state = MovementState.running;

        }

        else 
        {
            state = MovementState.idle;

        }

       

        if(m_rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;

        }

        else if(m_rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }
       


        if (Input.GetButtonDown("Jump") && isGround)
        {
            m_rb.velocity = new Vector2(m_rb.velocity.x, jump);

            isGround = false;
        }

        anim.SetInteger("State", (int)state);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }

    }
}
