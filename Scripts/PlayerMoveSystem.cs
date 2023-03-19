using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveSystem : MonoBehaviour
{   
    //privates
    private Rigidbody2D rb;
    private bool moveLeft;
    private bool moveRight;
    private bool m_FacingRight = true;
    private float horizontalMove;
    
    [Header("Settings")]
    public float Speed = 0f;

    [Header("Objects")]
    public AudioSource jumpSound;
    public Animator animator;
    public ParticleSystem jumpParticle;
    






    void Start()
    {

        //Find player Rigidbody component
        rb = GetComponent<Rigidbody2D>();

        // Set movement Default Value
        moveLeft = false;
        moveRight = false;
    }

    //Press down Left button
    public void PointerDownLeft()
    {
        moveLeft = true;
    }

    //Release Left button
    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    //press down Right button
    public void PointerDownRight()
    {
        moveRight = true;
    }

    //release Right button
    public void PointerUpRight()
    {
        moveRight = false;
    }

    // Using movement function
    void Update()
    {
        Movement();

    }

    private void Movement()
    {
        //pressing a key down
        if (Input.GetKeyDown("a"))
        {
            moveLeft = true;
        }

        //release a key 
        else if (Input.GetKeyUp("a"))
        {
            moveLeft = false;
        }

        //pressing d key down
        if (Input.GetKeyDown("d"))
        {
            moveRight = true;
        }

        //release d key
        else if (Input.GetKeyUp("d"))
        {
            moveRight = false;
        }



        // if moving left, make played speed negative(moving left) and flip if facing wrong direction
        if (moveLeft)
        {
            horizontalMove = -Speed;
            
            if (m_FacingRight)
            {
                Flip();
            }
            
        }


        // if moving right, make played speed positive(moving right) and flip if facing wrong direction
        else if (moveRight)
        {
            horizontalMove = Speed;

            if (!m_FacingRight)
            {
                Flip();
            }

        }

        // if not moving, speed is 0
        else
        {
            horizontalMove = 0;
        }
    
    }

    // updating player velocity
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }

    // function to flip player
    private void Flip()
    {
        m_FacingRight = !m_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // if colliding with platform, play sound
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            if (collision.relativeVelocity.y >= 0f)
            {
                jumpSound.Play();
                jumpParticle.Play();
                animator.Play("JumpAnimation");
            }

        }

    }
}
