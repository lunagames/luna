using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(GetComponent<EnemyDestructableHealth>() != null)
		{
			if(GetComponent<EnemyDestructableHealth>().health <= 0)
			{
				Destroy(gameObject);
			}

		}

	}
}
