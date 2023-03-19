using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	[Header("Settings")]
	public float jumpForce = 0f;
	public float boosterForce = 0f;
	public bool deathPlatform = false;
	public bool boostPlatform = false;
	public bool oneHitPlatform = false;
	public bool normalPlatform = false;

	[Header("Objects")]
	public DeathBox playerDead;
	
	public ParticleSystem destroyParticle;






	void Awake()
    {
		playerDead = GameObject.Find("Deathbox").GetComponent<DeathBox>();
	}

	
	


	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.relativeVelocity.y <= 0f)
		{
			Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
			if (rb != null)
			{
				if (boostPlatform)
				{
					Debug.Log("Boost");
					Vector2 velocity = rb.velocity;
					velocity.y = boosterForce;
					
					rb.velocity = velocity;
				}

				if (deathPlatform)
				{
					Debug.Log("Dead");
					playerDead.dead = true;
				}

				if (oneHitPlatform)
				{
					destroyParticle.Play();
					Debug.Log("OneHit");
					
					Vector2 velocity = rb.velocity;
					velocity.y = jumpForce;
					rb.velocity = velocity;
					

					Destroy(this.gameObject);
					Debug.Log("Onedestroyed");
					
				}
				
				if (normalPlatform)
                {
					Debug.Log("normal");
					Vector2 velocity = rb.velocity;
					velocity.y = jumpForce;
					rb.velocity = velocity;
				}
			}
		}
	}

	



}
