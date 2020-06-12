using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
	
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
	//[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
	//[SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
	//[SerializeField] private Transform m_CeilingCheck;

	//const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	//private bool m_Grounded;            // Whether or not the player is grounded.
	//const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	//private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	//[Header("Events")]
	//[Space]

	//[System.Serializable]
	//public class BoolEvent : UnityEvent<bool> { }


	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}



	public void Move(float horizontal, float vertical)
	{
		Vector3 targetVelocity;

		// Move the character by finding the target velocity
			targetVelocity = new Vector2(horizontal * 10f, vertical * 10f);
			
		
		// And then smoothing it out and applying it to the character
		m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

		// If the input is moving the player right and the player is facing left...
		if (move > 0 && !m_FacingRight)
		{
		// ... flip the player.
		Flip();
		}
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (move < 0 && m_FacingRight)
		{
		// ... flip the player.
		Flip();
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		transform.Rotate(0f, 180f, 0f);
	}
}
