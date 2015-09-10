using UnityEngine;
using System.Collections;

//Add this script to and object from the Object Pool that you would like to
//deactivate after a specified period of time

public class PooledObjectSetInactiveScript : MonoBehaviour {

	public float lifespan = 4f;

	void OnEnable()
	{
		Invoke ("SetSelfInactive", lifespan);
	}

	void SetSelfInactive()
	{
		gameObject.SetActive(false);
	}
	
	void OnDisable()
	{
		CancelInvoke();
	}
}
