using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class Abilities : MonoBehaviour {
	public GameObject player;
	public GameObject fireball;
	public GameObject pushForce;
	public float timeSlowSpeed = 0.5f;
	public AbilityBar abilityBar;
	public string activePower;
	public float T_abilityCost = 10;
	
	private bool powerActivated = false;
	private bool waveSpawned = false;
	//Fireball 
	private LunaCharacterController lunaCharacterController;
	private PlayerScript playerScript;
	private GameObject fireballSpawn;
	private GameObject forceWave;

	void Awake(){
		lunaCharacterController = FindObjectOfType<LunaCharacterController>();
		player = this.gameObject;
		abilityBar = GetComponent<AbilityBar>();
		playerScript = GetComponent<PlayerScript>();
		fireballSpawn = GameObject.Find("FireballSpawn");

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
		if(Input.GetKeyUp(KeyCode.F)||activePower == null||!powerActivated||abilityBar.CurrentAbilityCharge<=0){
			if(powerActivated){
				Time.timeScale = 1;
				abilityBar.abilityCost = 0;
				powerActivated = false;
			}
		}
		if(Input.GetKeyDown(KeyCode.F)){
			if(activePower == "ForcePush"&&abilityBar.CurrentAbilityCharge>=abilityBar.MaxAbilityCharge/10){
				forceWave = Instantiate(pushForce,transform.position,Quaternion.identity) as GameObject;
				forceWave.GetComponent<PushWaveController>().facingRight = lunaCharacterController.m_FacingRight;
				abilityBar.CurrentAbilityCharge -= abilityBar.MaxAbilityCharge * 0.10f;
			}
		}
		//Fireball shooting
		if(fireball && abilityBar.AbilityEnabled && playerScript.CurHealth > 0)
		{
			if(Input.GetKeyDown(KeyCode.S))
			{
				ShootFireball();
			}
		}
	}

	void ShootFireball()
	{
		Debug.Log ("Fireball Shot!");
		Instantiate (fireball,fireballSpawn.transform.position,Quaternion.identity);
		//decrement the abilitybar by 10% per shot
		abilityBar.CurrentAbilityCharge -= abilityBar.MaxAbilityCharge * 0.10f;
		
	}
}