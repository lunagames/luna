using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
	
	public static ObjectPool instance;
	
	/// <summary>
	/// The object prefabs which the pool can handle.
	/// </summary>
	public GameObject[] objectPrefabs;
	
	/// <summary>
	/// The pooled objects currently available.
	/// </summary>
	public List<GameObject>[] pooledObjects;
	
	/// <summary>
	/// The amount of objects of each type to buffer.
	/// </summary>
	public int[] amountToBuffer;
	public int defaultBufferAmount = 3;

	/// <summary>
	/// Will the list for each object pooled grow if another object is needed?
	/// </summary>
	public bool willGrow;

	void Awake ()
	{
		instance = this;
	}
	
	// Use this for initialization
	void Start ()
	{
		
		//Loop through the object prefabs and make a new list for each one.
		//We do this because the pool can only support prefabs set to it in the editor,
		//so we can assume the lists of pooled objects are in the same order as object prefabs in the array
		pooledObjects = new List<GameObject>[objectPrefabs.Length];
		
		int i = 0;
		foreach ( GameObject objectPrefab in objectPrefabs )
		{
			pooledObjects[i] = new List<GameObject>(); 
			int bufferAmount;
			
			if(i < amountToBuffer.Length) bufferAmount = amountToBuffer[i];
			else
				bufferAmount = defaultBufferAmount;
			
			for ( int n=0; n<bufferAmount; n++)
			{
				GameObject newObj = Instantiate(objectPrefab) as GameObject;
				newObj.name = objectPrefab.name;
				PoolObject(newObj);
			}
			
			i++;
		}
	}
	
	/// <summary>
	/// Gets a new object for the name type provided.  If no object type exists 
	/// then null will be returned.
	/// </summary>
	/// <returns>
	/// The object for type.
	/// </returns>
	/// <param name='objectType'>
	/// Object type.
	/// </param>
	public GameObject GetObjectForType (string objectType)
	{
		for(int i=0; i<objectPrefabs.Length; i++)
		{
			GameObject prefab = objectPrefabs[i];
			if(prefab.name == objectType)
			{
				Debug.Log(pooledObjects[i]);
				foreach (GameObject pooledObject in pooledObjects[i])
				{
					if(!pooledObject.activeInHierarchy)
					{
						return pooledObject;
					}

				 }
				if(willGrow)
				{
					GameObject obj = Instantiate(prefab) as GameObject;
					obj.name = prefab.name;
					PoolObject(obj);
					return(obj);
				}

			  }


		   }
		//If we have gotten here either there was no object of the specified type
		return null;
	}
	
	/// <summary>
	/// Pools the object specified.  Will not be pooled if there is no prefab of that type.
	/// </summary>
	/// <param name='obj'>
	/// Object to be pooled.
	/// </param>
	public void PoolObject ( GameObject obj )
	{
		for ( int i=0; i<objectPrefabs.Length; i++)
		{
			if(objectPrefabs[i].name == obj.name)
			{
				obj.SetActive(false);
				obj.transform.parent = transform;
				pooledObjects[i].Add(obj);
				return;
			}
		}
	}
	
}