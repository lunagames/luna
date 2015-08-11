using UnityEngine;
using System.Collections;

public class AbilityBar : MonoBehaviour {
	
	public GUIStyle BlackBar;
	public GUIStyle NoAbility;
	public GUIStyle TimeSlow;
	public GUIStyle TextField;
	
	public bool AbilityEnabled=false;
	public bool AbilityDraining=false;
	public float MaxAbilityCharge = 200;
	public float CurrentAbilityCharge = 0;
	public float abilityCost;
	
	public GUIStyle currentAbility;
	void Start(){
		currentAbility = NoAbility;
	}
	void Update(){
		
		if (CurrentAbilityCharge <= 0) {
			AbilityEnabled = false;
			CurrentAbilityCharge=0;
		}
		
		if (AbilityDraining==true){
			//Debug.Log("AbilityEnabled");
			CurrentAbilityCharge-=((Time.deltaTime*8)/Time.timeScale + (abilityCost/7));
		}
		
		
		
		
		
		
	}
	
	void OnGUI()
	{
		//if (!Death) {  //If NOT death
		
		
		//Experience bar
		GUI.Box (new Rect (10, 10, 200, 10), "", BlackBar);  //BlackBar bar hehind the text
		GUI.Box (new Rect (10, 10, CurrentAbilityCharge, 10), "", currentAbility);
		//GUI.Box (new Rect (20, 5, 200, 25), "XP: " + CurrentAbilityChange + "/" + MaxAbilityCharge, TextField);
		
		
		
		
	}
	
	public void FillAbilityBar()
	{
		//Debug.Log("Ability Bar Fill");
		CurrentAbilityCharge = MaxAbilityCharge;
		AbilityEnabled = false;
		AbilityDraining = false;
	}
	
	public void AbilityBarDrainStart()
	{
		//Debug.Log("Ability Bar Fill");
		AbilityDraining = true;
	}
	
	
	
	public void EmptyAbilityBar()
	{
		CurrentAbilityCharge = 0;
		AbilityEnabled = false;
		AbilityDraining = false;
	}
	
}