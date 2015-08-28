using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
	
	/// <summary>
	/// Fireball controller. After 1 shot, the fireballs no longer move when activated. 
    /// still spawns at fireball spawn position. no movement and no sound.???
	/// </summary>
	
public class FireballController : MonoBehaviour {
	
	private LunaCharacterController lunaCharacterController;
	private Rigidbody2D rigidBody2D;
	private float rScale;
	private float adjustedTime;
	private bool secondEnable = false;

	public float damage;
	public float speed;
	public GameObject fireballExplosion;
	public AudioClip fireballLaunchClip;
	public AudioClip explosionClip;

	// Use this for initialization
	void OnEnable() {

		rigidBody2D = GetComponent<Rigidbody2D>();
		lunaCharacterController = GameObject.FindGameObjectWithTag("Player").GetComponent<LunaCharacterController>();
		Quaternion newRotation;

		//this if statement and bool are to make sure the fireballLaunchClip does Not play when 
		//the scene is started and the fireballs are pooled, but only after. 
		//There is probably a better way to handle this bug but I couldnt find it yet.
		if(secondEnable)
		{
			AudioSource.PlayClipAtPoint(fireballLaunchClip,transform.position);
		}
		secondEnable = true;

		//adjust  the fireball speed if slowtime is active
		if(Time.timeScale == 1){
			adjustedTime = Time.deltaTime;
		}
		else if(Time.timeScale != 1){
			adjustedTime = Time.deltaTime / Time.timeScale;
		}
		//if the character is facing to the right, shoot to the right
		if(lunaCharacterController.m_FacingRight)
		{
			rigidBody2D.velocity = new Vector2(speed, 0f) * adjustedTime;
			//rotate the fireball to face the correct direction
			newRotation = Quaternion.Euler(0,0,0);
			transform.rotation = newRotation;
		}
		//if the character is facing left, shoot to the left
		else if (!lunaCharacterController.m_FacingRight)
		{
			rigidBody2D.velocity = new Vector2(speed * -1f, 0f) * adjustedTime; 
			newRotation = Quaternion.Euler(0,180,0);
			transform.rotation = newRotation;
		}

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//deplete the health of objects tagged destructable or enemy
		if(col.gameObject.tag == "Destructible" || col.gameObject.tag == "Enemy")
		{
			if(col.gameObject.GetComponent<EnemyDestructibleHealth>() != null)
			{
				col.gameObject.GetComponent<EnemyDestructibleHealth>().health -= damage;
			}

		}

		//create a fireball explosion and deactivate the fireball on impact 
		AudioSource.PlayClipAtPoint(explosionClip,transform.position);
		gameObject.SetActive(false);
		GameObject explosion = ObjectPool.instance.GetObjectForType("Explosion");
		if(explosion == null) return;
		//
		//			//set the fireballs position and activate it
		explosion.transform.position = transform.position;
		explosion.transform.rotation = Quaternion.identity;
		explosion.SetActive(true);
		//GameObject explosion = Instantiate(fireballExplosion,transform.position,Quaternion.identity) as GameObject;
		//GameObject.Destroy(explosion,2.5f);


	}



}
