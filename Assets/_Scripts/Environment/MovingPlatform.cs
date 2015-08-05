using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	private GameObject player;
		
	private int Marker = 0;
	public int speed =4;
	public Transform[] Waypoints;

	void Start () 
	{

		player = GameObject.Find("Player"); //Player's Character
	}

	// Update is called once per frame
	void Update () {
	
		transform.position = Vector3.MoveTowards (transform.position, Waypoints [Marker].transform.position, speed * Time.deltaTime);

		if (transform.position == Waypoints [Marker].transform.position) {
			Marker ++;
		}
		if (Marker == Waypoints.Length) {
			Marker=0;
		}

	}

	//If character collides with the platform, make it its child.
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
			MakeChild ();   
		}
	}
	//Once it leaves the platform, become a normal object again.
	void OnCollisionExit2D(Collision2D coll){
		if (coll.gameObject.tag == "Player") {
			ReleaseChild(); 
		}
	}
	
	void MakeChild(){
		player.transform.parent = transform;
	}
	
	void ReleaseChild(){
		player.transform.parent = null;
	}


}
