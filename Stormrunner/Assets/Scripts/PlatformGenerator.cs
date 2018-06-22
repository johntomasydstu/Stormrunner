using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform; //Platform that will be generated ahead of the player
	public Transform generationPoint; //The point ahead of the player where new platforms generated
	public float distanceBetween; //Distance between platforms

	private float platformWidth; //Width of the platform
	private SpriteRenderer spriteRenderer;

	public float distanceBetweenMin; //Min distance between platforms
	public float distanceBetweenMax; //Max distance between platforms

	//public GameObject[] thePlatforms; //Array of all the different platforms
	private int platformSelector; //Used to decide which platform to be selected
	private float[] platformWidths;

	public ObjectPooler[] theObjectPools;

	private float minHeight; //Minimum height platform spawns at
	private float maxHeight; //Maximum height platform spawns at
	public Transform maxHeightPoint; 
	public float maxHeightChange;
	private float heightChange;

	private CoinGenerator theCoinGenerator; //Coin Generator
	public float randomCoinThreshold; //Used to decide if coins should be created or not

	//Platform Sprite List
	public Sprite[] platformSprites;

	public int biome; //Current Biome: 0 = Grass, 3 = Snow, 6 = Desert

	private int platformLastChildIndex;

	// Use this for initialization
	void Start () 
	{
		//platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;


		platformWidths = new float[theObjectPools.Length]; 

		for (int i = 0; i < theObjectPools.Length; i++)
		{
			platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}

		minHeight = transform.position.y; //Minimum height is the y pos of PlatformGenerator object
		maxHeight = maxHeightPoint.position.y; 

		theCoinGenerator = FindObjectOfType<CoinGenerator> (); //Initialization

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (transform.position.x < generationPoint.position.x) //If the x position of the PlatformGenerator is less than the Generation Point's x position
		{
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			platformSelector = Random.Range (0, theObjectPools.Length);

			heightChange = transform.position.y + Random.Range(maxHeightChange, - maxHeightChange);

			if (heightChange > maxHeight) 
			{
				heightChange = maxHeight;
			} 
			else if (heightChange < minHeight) 
			{
				heightChange = minHeight;
			}

			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);


			//Instantiate (/* thePlatform */ thePlatforms[platformSelector], transform.position, transform.rotation); //Create new platform

			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject (); //Create a new platform equal to an unused object from theObjectPool.pooledObjects list

			platformLastChildIndex = newPlatform.gameObject.transform.childCount -1;
	
			newPlatform.transform.position = transform.position;
	

			newPlatform.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = platformSprites[0+biome]; 
		
			newPlatform.gameObject.transform.GetChild(newPlatform.gameObject.transform.childCount -1).GetComponent<SpriteRenderer>().sprite = platformSprites[2+biome]; 

			for (int i = 1; i < newPlatform.gameObject.transform.childCount - 1; i++)
			{
				newPlatform.gameObject.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = platformSprites[1+biome]; 
			}
				

			newPlatform.SetActive (true); //activates object

			if (Random.Range (0f, 100f) < randomCoinThreshold) 
			{
				theCoinGenerator.SpawnCoins (new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z)); //Spawn Coins
			}
				
			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);



		}
	}
}
