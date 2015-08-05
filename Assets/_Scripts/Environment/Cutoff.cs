using UnityEngine;
using System.Collections;

public class Cutoff : MonoBehaviour {

	public GameObject Player;


	void Awake () {
	
		Player = GameObject.FindGameObjectWithTag ("Player");

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Player.transform.position.x <= transform.position.x) {


			//Player.transform.position = transform.position;

			//I would rather Cutoff do this...
			Vector3 temp = Player.transform.position;
			temp.x=transform.position.x;
			Player.transform.position = temp;
		}

	}
}
