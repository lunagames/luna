using UnityEngine;
using System.Collections;

namespace UnityStandardAssets._2D
{
	public class Abilities : MonoBehaviour {

		public GameObject player;
		public float timeSlowSpeed = 0.5f;
		public GameObject fireball;
		AbilityBar pStats;


		private LunaCharacterController lunaCharacterController;
		private PlayerScript playerScript;
		private GameObject fireballSpawn;
		void Awake(){
			player = GameObject.FindGameObjectWithTag("Player");
			lunaCharacterController = GetComponent<LunaCharacterController>();
			playerScript = GetComponent<PlayerScript>();
			pStats = GetComponent<AbilityBar> ();
			fireballSpawn = GameObject.FindGameObjectWithTag("FireballSpawn");
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

			//Fireball shooting
			if(fireball && pStats.AbilityEnabled && playerScript.CurHealth > 0)
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
			pStats.CurrentAbilityCharge -= pStats.MaxAbilityCharge * 0.10f;
			
		}
	}
}

