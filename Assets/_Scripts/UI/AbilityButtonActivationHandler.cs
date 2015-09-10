using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AbilityButtonActivationHandler : MonoBehaviour {

	//this script is attached to the abilityPickerUI and detects if the abilities have been aquired.
	//if so it makes the appropriate button interactable so that the ability can be used.

	public static bool fireballAbilityAquired = false;
	public static bool slowTimeAbilityAquired = false;

	public Transform fireballButton;
	public Transform slowTimeButton;

	// Use this for initialization
	void Start () {


	
	}
	
	// Update is called once per frame
	void Update () {

		ActivateDeactivateButton(fireballButton,fireballAbilityAquired);
		ActivateDeactivateButton(slowTimeButton,slowTimeAbilityAquired);

	}

	void ActivateDeactivateButton(Transform button, bool abilityAquired)
	{
		if(abilityAquired)
		{
			button.GetComponent<Button>().interactable = true;
		}
		else
		{
			button.GetComponent<Button>().interactable = false;
		}

	}
}
