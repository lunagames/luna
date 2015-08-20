﻿using UnityEngine;
using System.Collections;

public class FireballAbilityGainGemScript : MonoBehaviour {

	public GameObject CoinCollectNoise;

	//public AbilityButtonActivationHandler abilityButtonHandler;

	void Start()
	{
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.tag == "Player") 
		{
			AbilityButtonActivationHandler.fireballAbilityAquired = true;
			CoinCollectNoise = GameObject.FindGameObjectWithTag ("CoinCollectNoise");
			AudioSource audio = CoinCollectNoise.GetComponent<AudioSource>();
			audio.Play();
			Destroy (gameObject);
		}
		
	}
}
