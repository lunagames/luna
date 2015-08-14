using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(GetComponent<EnemyDestructibleHealth>() != null)
		{
			if(GetComponent<EnemyDestructibleHealth>().health <= 0)
			{
				Destroy(gameObject);
			}

		}

	}
}
