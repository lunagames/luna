using UnityEngine;
using System.Collections;

public class AbilityBar : MonoBehaviour {

	public GUIStyle BlackBar;
	public GUIStyle ExperienceBar;
	public GUIStyle TextField;

	public float MaxAbilityCharge = 200;
	public float CurrentAbilityChange = 0;

	void OnGUI()
	{
		//if (!Death) {  //If NOT death
			
			
		//Experience bar
		GUI.Box (new Rect (20, 5, 200, 25), "", BlackBar);  //BlackBar bar hehind the text
		GUI.Box (new Rect (20, 5, CurrentAbilityChange, 25), "", ExperienceBar);
		//GUI.Box (new Rect (20, 5, 200, 25), "XP: " + CurrentAbilityChange + "/" + MaxAbilityCharge, TextField);
			
			
			
			
		}

	public void FillAbilityBar()
	{
		CurrentAbilityChange = MaxAbilityCharge;
	}

	public void EmptyAbilityBar()
	{
		CurrentAbilityChange = 0;
	}

	}
