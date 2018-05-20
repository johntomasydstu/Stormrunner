using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

	public GameObject pooledObject; //Object to be pooled (platform prefab)

	public int pooledAmount; //An amount of objects to automatically pool

	List<GameObject> pooledObjects; //List of pooled Objects



	// Use this for initialization
	void Start () 
	{
		pooledObjects = new List<GameObject> ();

		//Add to pooledObjects list
		for (int i = 0; i < pooledAmount; i++) 
		{
			GameObject obj = (GameObject) Instantiate(pooledObject); //Instantiates a pooledObject as obj
			obj.SetActive (false); //Deactivate obj
			pooledObjects.Add(obj); //Add object to pooledObjects list
		}
	}

	//Find available pooledObject that is inactive, returns the particular pooledObject
	public GameObject GetPooledObject()
	{
		for(int i = 0; i < pooledObjects.Count; i++)
		{
			if (!pooledObjects [i].activeInHierarchy) //if not active
			{
				return pooledObjects[i]; //returns the object at position i of pooledObjects
			}
		}

		//If no inactive objects are found within the pooledObjects list, the following will 
		//run to instantiate a new object, deactivate it, append it to pooledObjects, and
		//return the new inactive object:

		GameObject obj = (GameObject) Instantiate(pooledObject); //Instantiates a pooledObject as obj
		obj.SetActive (false); //Deactivate obj
		pooledObjects.Add(obj); //Add obj to pooledObjects list
		return obj; //returns (obj) the new object added to the pooledObjects list
	}
}
