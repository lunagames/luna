using UnityEngine;
using System.Collections;

public class Gem : MonoBehaviour {

	public GameObject CoinCollectNoise;

	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D other)
	{
	
		if (other.tag == "Player") 
		{
			CoinCollectNoise = GameObject.FindGameObjectWithTag ("CoinCollectNoise");
			AudioSource audio = CoinCollectNoise.GetComponent<AudioSource>();
			audio.Play();
			Destroy (gameObject);
		}

	}
}
