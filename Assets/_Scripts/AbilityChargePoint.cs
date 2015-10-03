using UnityEngine;
using System.Collections;

public class AbilityChargePoint : MonoBehaviour {

	public GameObject Player;

	public GameObject abilityPickerUI;

	public float chargeDelay;

	private float nextUse = 5;

	void Awake()
	{
		Player = GameObject.FindGameObjectWithTag ("Player");

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.tag == "Player" && Time.time >= nextUse) {


			activateStation();
			nextUse = Time.time + chargeDelay;

			
		}
	}
	
	
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player") {
			
			AbilityBar pstats = Player.GetComponent<AbilityBar> ();
			pstats.AbilityBarDrainStart ();
			
		}
	}
	void activateStation(){

		//activate the ability picker UI and freeze time
		Time.timeScale = 0;
		AbilityBar abilityBar = Player.GetComponent<AbilityBar>();
		abilityBar.EmptyAbilityBar();
		abilityPickerUI.SetActive(true);
		
		
		
		//AbilityBar pstats = Player.GetComponent<AbilityBar> ();
		
		//Debug.Log ("Made contact");
		AudioSource audio = GetComponent<AudioSource>();
		audio.Play();

	}
}