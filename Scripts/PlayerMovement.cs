using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
	
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;
	private Vector3 m_Velocity = Vector3.zero;

	public float moveSpeed = 0f;
	public float horizontalMove = 0f;

	[Header("Objects")]

	public AudioSource jumpSound;
	public ParticleSystem jumpParticle;

	

	private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
		
	}

    void Update()
    {
		

		horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    void FixedUpdate()
    {
		Move(horizontalMove * Time.deltaTime);
	}

	

	public void Move(float move)
	{
		Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
		m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

		if (move > 0 && !m_FacingRight)
		{
			
			Flip();
		}

		else if (move < 0 && m_FacingRight)
		{

			Flip();
		}
	}


	private void Flip()
	{
		m_FacingRight = !m_FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "Platform")
		{
			if (collision.relativeVelocity.y >= 0f)
            {
				jumpSound.Play();
				jumpParticle.Play();
			}
				
		}

	}

}
