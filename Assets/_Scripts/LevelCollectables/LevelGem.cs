using UnityEngine;
using System.Collections;

public class LevelGem : MonoBehaviour {

	public GameObject CoinCollectNoise;
	
	
	void Awake(){
		LevelDoor.collectedCount++;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.tag == "Player") 
		{
			CoinCollectNoise = GameObject.FindGameObjectWithTag ("CoinCollectNoise");
			AudioSource audio = CoinCollectNoise.GetComponent<AudioSource>();
			audio.Play();
			LevelDoor.collectedCount++;
			Destroy (gameObject);
		}
		
	}
}
