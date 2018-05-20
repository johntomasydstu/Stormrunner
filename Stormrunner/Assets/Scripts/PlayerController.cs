using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed; //The Speed which the player moves at
	public float jumpForce; //The player's jump force

	public float jumpTime; //How long the player can continue jumping when the jump button is held down
	private float jumpTimeCounter; //Counter that uses the jump time to control the player.

	private Rigidbody2D myRigidbody; //Rigid Body belonging to the object (player) the script is attatched to 

	public bool grounded; //If player is on the ground, this variable is set to true.
	public LayerMask whatIsGround; //The Ground

	private Collider2D myCollider; //Player's Collider

	private Animator myAnimator; //Player's Animator



	// Use this for initialization
	void Start () 
	{
		myRigidbody = GetComponent<Rigidbody2D> (); //Sets myRigidbody to the player's RigidBody2D component
	
		myCollider = GetComponent<Collider2D> (); //Sets myCollider to the player's Collider2D component

		myAnimator = GetComponent<Animator> (); //Sets myAnimator to the player's Animator component

		jumpTimeCounter = jumpTime;
	}
	
	// Update is called once per frames
	void Update () 
	{
		grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y); //The player's x velocity is set to moveSpeed, the player's y velocity remains the same

		//Jump
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //Checks if either the Space Bar or the Left Mouse Button is pressed
		{
			if (grounded) 
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce); //The player's x velocity remains the same, y velocity is set to jumpForce
			}
		}

		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) 
		{
			if (jumpTimeCounter > 0) 
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce); //The player's x velocity remains the same, y velocity is set to jumpForce
				jumpTimeCounter -= Time.deltaTime; //decrement until jumpTimeCounter is 0
			}
		}

		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) 
		{
			jumpTimeCounter = 0;
		}

		if (grounded)
		{
			jumpTimeCounter = jumpTime;
		}

		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x); //Sets the Animator variable "Speed" to the x value of the Player's Rigidbody Velocity
		myAnimator.SetBool("Grounded", grounded); //Sets the Animator variable "Grounded" to grounded

	}
}
