using UnityEngine;
using System.Collections;

public class AbilityChargePoint : MonoBehaviour {

	public GameObject Player;

	void Awake()
	{
		Player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {

			AbilityBar pstats = Player.GetComponent<AbilityBar> ();
			pstats.FillAbilityBar ();
			//Debug.Log ("Made contact");
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();

			
		}
	}
	
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
			

			
		}
	}
}