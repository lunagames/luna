using UnityEngine;
using System.Collections;

public class PushWaveController : MonoBehaviour {
	public bool facingRight;
	public float waveLifeTime = 0.5f;
	public int waveSpeed = 15;

	private float lifeTime;
	// Use this for initialization
	void Start () {
		//flip wave facing direction
		if(!facingRight){
			Vector3 horizontalScale = transform.localScale;
			horizontalScale.x *= -1;
			transform.localScale = horizontalScale;
		}
		lifeTime = Time.time + waveLifeTime;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time >= lifeTime){
			Destroy(this.gameObject);
		}
		if(facingRight){
			this.transform.position = new Vector3(this.transform.position.x + (waveSpeed*Time.deltaTime),this.transform.position.y,this.transform.position.z);
		}else{
			this.transform.position = new Vector3(this.transform.position.x - (waveSpeed*Time.deltaTime),this.transform.position.y,this.transform.position.z);
		}
		this.transform.localScale *= 1.05f;
	}
}
