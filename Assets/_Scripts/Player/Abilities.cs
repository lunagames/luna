using UnityEngine;
using System.Collections;

public class Abilities : MonoBehaviour {
	public GameObject player;
	public float timeSlowSpeed = 0.5f;
	void Awake(){
		player = GameObject.FindGameObjectWithTag("Player");
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F)){
			Time.timeScale = timeSlowSpeed;
		}
		if(Input.GetKeyUp(KeyCode.F)){
			Time.timeScale = 1;
		}
	}
}
