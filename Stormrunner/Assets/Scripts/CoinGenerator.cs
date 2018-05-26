using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

	public ObjectPooler coinPool; //Coin Pooler

	public float distanceBetweenCoins; //Distance between coins

	//Create coin, set position of it, make sure it's active in the world
	public void SpawnCoins (Vector3 startPosition)
	{
		GameObject coin1 = coinPool.GetPooledObject (); //Get coin object
		coin1.transform.position = startPosition; //Set position to start position
		coin1.SetActive (true); //Activate coin

		GameObject coin2 = coinPool.GetPooledObject (); //Get coin object
		coin2.transform.position = new Vector3 (startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z); //Set position to start position
		coin2.SetActive (true); //Activate coin

		GameObject coin3 = coinPool.GetPooledObject (); //Get coin object
		coin3.transform.position = new Vector3 (startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z); //Set position to start position
		coin3.SetActive (true); //Activate coin
	}
}
