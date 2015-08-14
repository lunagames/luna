using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
	
	
	
public class FireballController : MonoBehaviour {
	
	private LunaCharacterController lunaCharacterController;
	private Rigidbody2D rigidBody2D;
	private float rScale;
	private float adjustedTime;

	public float damage;
	public float speed;
	
	// Use this for initialization
	void Start () {
		if(Time.timeScale == 1){
			adjustedTime = Time.deltaTime;
		}
		else if(Time.timeScale != 1){
			adjustedTime = Time.deltaTime / Time.timeScale;
		}
		rigidBody2D = GetComponent<Rigidbody2D>();
		lunaCharacterController = GameObject.FindGameObjectWithTag("Player").GetComponent<LunaCharacterController>();
		Quaternion newRotation;
		
		//if the character is facing to the right, shoot to the right
		if(lunaCharacterController.m_FacingRight)
		{
			rigidBody2D.velocity = new Vector2(speed, 0f) * adjustedTime;
			//rotate the fireball to face the correct direction
			newRotation = Quaternion.Euler(0,0,0);
			transform.rotation = newRotation;
		}
		//if the character id facing left, shoot to the left
		else if (!lunaCharacterController.m_FacingRight)
		{
			rigidBody2D.velocity = new Vector2(speed * -1f, 0f) * adjustedTime; 
			newRotation = Quaternion.Euler(0,180,0);
			transform.rotation = newRotation;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Destructable" || col.gameObject.tag == "Enemy")
		{
			col.gameObject.GetComponent<EnemyDestructableHealth>().health -= damage;
			//GameObject.Destroy(col.gameObject);
		}
		GameObject.Destroy(gameObject);
	}

}
