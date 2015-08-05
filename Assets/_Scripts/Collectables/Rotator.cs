using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	public float speed = 1;

	// Update is called once per frame
	void Update () {
	
		transform.Rotate(new Vector3(15*speed,30*speed, 45*speed)* Time.deltaTime);

	}
}
