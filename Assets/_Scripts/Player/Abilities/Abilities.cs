using UnityEngine;
using System.Collections;

public class Abilities : MonoBehaviour {
	public GameObject player;
	public float timeSlowSpeed = 0.5f;
	public AbilityBar abilityBar;
	public string activePower;
	public float T_abilityCost = 10;
	
	private bool powerActivated = false;
	void Awake(){
		player = this.gameObject;
		abilityBar = FindObjectOfType<AbilityBar>();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.F)){
			if(activePower == "TimeSlow"){
				if(abilityBar.CurrentAbilityCharge>0){
					Time.timeScale = timeSlowSpeed;
					abilityBar.abilityCost = T_abilityCost;
					powerActivated = true;
				}
			}
		}
		if(Input.GetKeyUp(KeyCode.F)||activePower == null||!powerActivated){
			if(powerActivated){
				Time.timeScale = 1;
				abilityBar.abilityCost = 0;
				powerActivated = false;
			}
		}
	}
}