using UnityEngine;
using System.Collections;

public class SlowTimeZone : MonoBehaviour {
	public AbilityBar abilityBar;
	
	private bool playerEntered = false;
	// Use this for initialization
	void Start () {
		abilityBar = FindObjectOfType<AbilityBar>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "Player"){
			Debug.Log ("Time Power Triggered");
			col.gameObject.GetComponent<Abilities>().activePower = "TimeSlow";
			abilityBar.currentAbility = abilityBar.TimeSlow;
			playerEntered = true;
		}
	}
	void OnTriggerExit2D(Collider2D col){
		if(playerEntered){
			col.gameObject.GetComponent<Abilities>().activePower = null;
			abilityBar.currentAbility = abilityBar.NoAbility;
			Debug.Log ("Time Power Lost");
		}
	}
}