using UnityEngine;
using System.Collections;

public class NPCCollision : MonoBehaviour {

	public Canvas canvas;

	void Start()
	{
		canvas.enabled=false;
	}



	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") {

			//Debug.Log ("Made contact");
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play();
			canvas.enabled = true;
			
		}
	}

		
	void OnTriggerExit2D(Collider2D other)
		{
			if (other.tag == "Player") {
				
				canvas.enabled=false;
				
			}
	}
}
	
