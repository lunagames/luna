using UnityEngine;
using System.Collections;

public class DeathScript : MonoBehaviour {

	public GameObject Player;
	//Spawns
	public GameObject Spawn;
	//End

	void Awake () {
		Player = GameObject.FindGameObjectWithTag ("Player");
		Spawn = GameObject.FindGameObjectWithTag ("Spawn");
		}

	public void DeathIdentifier(){

		transform.position = Spawn.transform.position;

		AbilityBar pstats = Player.GetComponent<AbilityBar> ();
		pstats.EmptyAbilityBar ();

	}

}
