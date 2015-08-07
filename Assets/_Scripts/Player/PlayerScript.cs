using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public GameObject Player;

	public float MaxHealth = 200;
	public float CurHealth = 200; //CurHealth = current health

	public int PlayerLives = 5;

	//Specific relation to health modification
	public float HealthModTalent = 1.1f; //If we have a talent wish increases the health it will be assigned to this number
	public float HealthModMofifier = 1.1f; //if we have a power which increases health it will be assigned to this number
	//End

	//Specific powerups in releations to block or otherwise abilitier which take damage away from the player health
	public float DamageResistance; //If we get a power up wish increses this float, then the damage the player the player should recieve to his/her life is then taken out of this
									//Consider making the bar a type of which is substractable from a definaed number
	public float SetDamageResistanceMaxVaule;   //Tie this in with above
	//End

	//Releation to player Experience
	//public float MaxExp = 200;
	//public float CurExp = 0;
	//public float NextLevelExpIncrease = 1.1f; //Changes the value of the exp increase each turn
	//public float NextLevelHealthIncrease = 1.1f; //changes the value of the health increase each turn
	//public float ExperienceMod = 1.1f; //If you obtain an powerup which temp increases your expeience gains
	//public float ExperienceModTalent = 1.1f; //Small number ADDED to experience gains each time you obtain exp (+ 5exp forever)
	//public int PlayerLevel = 1; //Set level cap at 100
	//End

	//GUI
	public GUIStyle BlackBar;
	public GUIStyle HealthBar;
	public GUIStyle TextField;
	public GUIStyle CharName;
	public GUIStyle ExperienceBar;
	//End


	//Text Fields
	public string PlayerName = "";
	//End

	//Curreny and Loot
	public int Coins;

	//Loot Objects
	public GameObject CoinItem;
	public GameObject GemItem; //Possible Breakdown ( Ruby, Diamond, Saphire)
	//Ensure that you make the powerups a rare loot drop
	public GameObject  AdditionalLife; //Ensure that an addtional life is added
	//End Sub
	//End

	//Bools and Tools
	public bool Death = false;
	public bool CheatWindow = false;
	public bool StatWindow = false;
	//End

	//Timers
	public float Despawncountdown = 1;
	public int Despawn = 5;
	//Powerups
	public float WeapCooldown = 1;
	//End Sub
	//End

	//Powerps
	public GameObject Fireball;
	public GameObject Iceball;
	public ParticleEmitter InvincibleCloak;
	//End


	//Spawns
	public GameObject Spawn;

	//End



	void Awake () {
	
		Player = GameObject.FindGameObjectWithTag ("Player");
		Spawn = GameObject.FindGameObjectWithTag ("Spawn");

		//Load ();
	}

	void OnGUI()
	{
		if (!Death) {  //If NOT death
			//CharacterStats
			//GUI.Box (new Rect (20, 5, 200, 25), "", BlackBar);  //BlackBar bar hehind the text
			//GUI.Box (new Rect (20, 5, 100, 25), PlayerName, CharName); //
			//GUI.Box (new Rect (120, 5, 80, 25), "Player Level: " + PlayerLevel, CharName);

			//HealthBar
			//GUI.Box (new Rect (20, 35, 200, 25), "", BlackBar);  //BlackBar bar hehind the text
			//GUI.Box (new Rect (20, 35, CurHealth, 25), "", HealthBar);
			//GUI.Box (new Rect (20, 35, 200, 25), "Health: " + CurHealth + "/" + MaxHealth, TextField);

			//Experience bar
			//GUI.Box (new Rect (20, 65, 200, 25), "", BlackBar);  //BlackBar bar hehind the text
			//GUI.Box (new Rect (20, 65, CurExp, 25), "", ExperienceBar);
			//GUI.Box (new Rect (20, 65, 200, 25), "XP: " + CurExp + "/" + MaxExp, TextField);
		
			//Player  Currency
			//GUI.Box (new Rect (20, 95, 200, 25), "", BlackBar);
			//GUI.Box (new Rect (20, 95, 200, 25), "Gems: " + Coins +"/35", TextField);

			//Player Lives
			//GUI.Box (new Rect (20, 125, 200, 25), "", BlackBar);
			//GUI.Box (new Rect (20, 125, 200, 25), "Lives: " + PlayerLives, TextField);


		}

		//if (Death) {
			//GUI.Box (new Rect(0,0,Screen.width,Screen.height),"Game Over \n \n \n Respawing in... " + Despawn + " seconds");
		//}

	}

	// Update is called once per frame
	void Update () {
	
		MaxHealth = 200; //+ (PlayerLevel-1) * HealthModMofifier * HealthModTalent *NextLevelHealthIncrease;
		//MaxExp = 200 + (PlayerLevel - 1) * ExperienceMod * ExperienceModTalent * NextLevelExpIncrease;

		if (CurHealth >= MaxHealth) {
			CurHealth = MaxHealth;
		}
		
		if (CurHealth <= 0) {
			CurHealth=0;
			DeathIdentifier();
		}
		
		//if (CurExp >= MaxExp) {
			//LevelUp ();
			//CurExp = 0;
		//}
		
		//if (CurExp <= 0) {
			//CurExp = 0;
		//}

		//if (PlayerLevel >= 100) {
			//PlayerLevel = 100;
			//CurExp = 0;
		//}

		if (Despawncountdown <= 1  && Death) 
		{
			Despawncountdown -= Time.deltaTime;
		}
		if (Despawncountdown <= 0) {
			Despawn -= 1;
			Despawncountdown = 1;
		}
		if(Despawn <=0)
		{
			//Save ();
			Application.LoadLevel("Level 01");
		}

		if (Death) {

			//Add code to take away palyer control
			//transform.position = Spawn.transform.position;

		}




	}

	public void DeathIdentifier(){

		//if (PlayerLives >= 0) {
			//PlayerLives -= 1;
			//Debug.Log ("Life lost");

			transform.position = Spawn.transform.position;

		AbilityBar pstats = Player.GetComponent<AbilityBar> ();
		pstats.EmptyAbilityBar ();

			CurHealth=MaxHealth;
		//}

		//if (PlayerLives <0)		{
			//DeathSequence();
		//}





	}

	//void LevelUp()
	//{

		//PlayerLevel += 1;
		//CurExp = 0;
		//CurHealth = MaxHealth;

	//}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log ("Player Collision Detected");
		if(other.tag=="Gem")
		{
			Coins+= 1;

		}

	}

	//void DeathSequence(){

		//Death = true; //Save Coins etc
		//Save ();
		//Debug.Log ("Game Over");

	//}

	void LootManagement()
	{

	}



	void Save()
	{
		PlayerPrefs.SetInt ("PlayerCurrency", Coins);
		//PlayerPrefs.SetFloat ("PlayerExperience", CurExp);
		//PlayerPrefs.SetInt ("PlayerLevel",PlayerLevel );
		Debug.Log ("Saved coins" + PlayerPrefs.GetInt ("PlayerCurrency") + " Current Exp: " + PlayerPrefs.GetFloat("PlayerExperience") + "Player Level: " + PlayerPrefs.GetInt("PlayerLevel"));
	}

	void Load()
	{

		Debug.Log ("Load Triggered");
		//PlayerName = PlayerPrefs.GetString ("CharName"); //To be set int menu
		Coins=PlayerPrefs.GetInt("PlayerCurrency");
		//Important to set level before EXP incase of level up
		//PlayerLevel = PlayerPrefs.GetInt("PlayerLevel");
		//CurExp = PlayerPrefs.GetInt("PlayerExperience");
//		ExperienceMod = PlayerPrefs.GetFloat ("ExperienceMod");
//		ExperienceModTalent = PlayerPrefs.GetFloat ("ExperienceModTalent");
//		HealthModMofifier=PlayerPrefs.GetFloat ("HealthModMofifier");
//		HealthModTalent = PlayerPrefs.GetFloat ("HealthModTalent");



	}

	void OnApplicationQuit()
	{

		//Save ();

	}







}
