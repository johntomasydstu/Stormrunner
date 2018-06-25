using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAndBiomeController : MonoBehaviour {

	public float moveSpeed; //The Speed which the player moves at
	private float moveSpeedStore; //Stores the initial moveSpeed
	public float speedMultiplier; //The value at which the moveSpeed is multiplied

	public float speedIncreaseMilestone; //Milestone at which the moveSpeed is multiplied
	private float speedIncreaseMilestoneStore; //Stores the initial speedIncreaseMilestoneCount


	private float speedMilestoneCount; //Used to keep track - everytime a set distance is reached add speedIncreaseMilestone
	private float speedMilestoneCountStore; //Stores the initial speedMilestoneCount


	public float jumpForce; //The player's jump force

	public float jumpTime; //How long the player can continue jumping when the jump button is held down
	private float jumpTimeCounter; //Counter that uses the jump time to control the player.

	private bool stoppedJumping; //Becomes true when player hits the ground, becomes false when start jumping

	private Rigidbody2D myRigidbody; //Rigid Body belonging to the object (player) the script is attatched to 

	public bool grounded; //If player is on the ground, this variable is set to true.
	public LayerMask whatIsGround; //The Ground
	public Transform groundCheck; //Ground Check object
	public float groundCheckRadius; //Radius of the Ground Check object

	//private Collider2D myCollider; //Player's Collider

	private Animator myAnimator; //Player's Animator'


	public GameManager theGameManager; //Game Manager
	public PlatformGenerator thePlatformGenerator; //Game Manager


	public bool dead; //Is the player dead?

	public AudioClip jumpSound; //Jump Sound
	public AudioClip deathSound; //Death Sound

	private int biomeChange; 
	public Sprite[] backgroundSprites;
	public GameObject[] backgroundLayers;
	private bool rightBackgroundLayerIsVisible; //Is the right background visible?

	// Use this for initialization
	void Start () 
	{
		//Sets the biome to 0 (grass) at the beginning of the game.
		thePlatformGenerator.biome = 0;


		myRigidbody = GetComponent<Rigidbody2D> (); //Sets myRigidbody to the player's RigidBody2D component
	
		//myCollider = GetComponent<Collider2D> (); //Sets myCollider to the player's Collider2D component

		myAnimator = GetComponent<Animator> (); //Sets myAnimator to the player's Animator component

		jumpTimeCounter = jumpTime;

		speedMilestoneCount = speedIncreaseMilestone;

		moveSpeedStore = moveSpeed; //Set initial value
		speedMilestoneCountStore = speedMilestoneCount; //Set initial value
		speedIncreaseMilestoneStore = speedIncreaseMilestone; //Set initial value

		stoppedJumping = true;
		dead = false; //Player starts the game as not dead
	}
	
	// Update is called once per frames
	void Update () 
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround); //Determine if play is on the ground

		//Speed Multiply
		if (transform.position.x > speedMilestoneCount)
		{
			speedMilestoneCount += speedIncreaseMilestone; //When player hits milestone, increase to the new milestone

			speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier; //Next milestone will be slightly larger than the previous milestone

			moveSpeed = moveSpeed * speedMultiplier; //Movespeed is multiplied by the speedMultiplier

			//If the movespeed is greater than 13, it is then set to 13.0
			if (moveSpeed > 13) 
			{
				moveSpeed = 13;
			}

			ChangeBiome ();

		} 



		backgroundChange ();





		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y); //The player's x velocity is set to moveSpeed, the player's y velocity remains the same

		//Jump
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //Checks if either the Space Bar or the Left Mouse Button is pressed
		{
			if (grounded) 
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce); //The player's x velocity remains the same, y velocity is set to jumpForce
				stoppedJumping = false;
				FindObjectOfType<AudioManager>().Play("Jump"); //Play Jump Sound
			}
		}

		if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) && !stoppedJumping) 
		{
			if (jumpTimeCounter > 0) 
			{
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce); //The player's x velocity remains the same, y velocity is set to jumpForce
				jumpTimeCounter -= Time.deltaTime; //decrement until jumpTimeCounter is 0
			}
		}

		if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp (0)) 
		{
			jumpTimeCounter = 0; //jumpTimeCounter is set to 0
			stoppedJumping = true; //Player has stopped jumping
		}

		if (grounded)
		{
			jumpTimeCounter = jumpTime; //jumpTimeCounter is set to jumpTime (time in the air)
		}

		myAnimator.SetFloat ("Speed", myRigidbody.velocity.x); //Sets the Animator variable "Speed" to the x value of the Player's Rigidbody Velocity
		myAnimator.SetBool("Grounded", grounded); //Sets the Animator variable "Grounded" to grounded
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "killbox") 
		{
			dead = true; //Player is dead
			theGameManager.RestartGame (); //Restart the game
			moveSpeed = moveSpeedStore; //Reset to initial value
			speedMilestoneCount = speedMilestoneCountStore; //Reset to initial value
			speedIncreaseMilestone = speedIncreaseMilestoneStore; //Reset initial value
			FindObjectOfType<AudioManager>().Play("Death");  //Play Death Sound
			thePlatformGenerator.biome = 0; //Set the biome to 0 (grass)
		}
	}

	//Changes the biome. Will only have an affect if the right background layers are NOT visible within the camera's view.
	public void ChangeBiome()
	{
		rightBackgroundLayerIsVisible = backgroundLayers [2].gameObject.transform.GetChild (backgroundLayers [2].gameObject.GetComponent<ScrollingBackground> ().rightIndex).GetComponent<Renderer> ().isVisible;

		if (rightBackgroundLayerIsVisible == false) 
		{
			Debug.Log ("Biome Changing my nigga!");
			biomeChange = Random.Range (1, 6); //biomeChange is set to a number between 1 (inclusive) and 5 (exclusive) - meaning a number between 1 and 4.

			//Biome Change
			if (biomeChange == 1) //Grass biome
			{
				thePlatformGenerator.biome = 0;
			} 
			else if (biomeChange == 2) //Purple biome
			{
				thePlatformGenerator.biome = 3;

			} 
			else if (biomeChange == 3) //Desert biome
			{
				thePlatformGenerator.biome = 6;

			}
			else if (biomeChange == 4) //Snow biome
			{
				thePlatformGenerator.biome = 9;

			}
			else if (biomeChange == 5) //Stone biome
			{
				thePlatformGenerator.biome = 12;
			}


		}


	}

	public void backgroundChange()
	{
		//Background Change
		for (int i = 0; i < 3; i++)
		{
			backgroundLayers[i].gameObject.transform.GetChild(backgroundLayers[i].gameObject.GetComponent<ScrollingBackground>().rightIndex).GetComponent<SpriteRenderer>().sprite = 
				backgroundSprites[i+thePlatformGenerator.biome]; //The right index child (background on the right side) of BackgroundLayer [i]'s sprite is changed to fit the new biome.
		}
	}


}
