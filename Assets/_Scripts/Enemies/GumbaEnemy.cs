using UnityEngine;
using System.Collections;

public class GumbaEnemy : MonoBehaviour {

	public float velocity = 1f;
	private Rigidbody2D m_Rigidbody2D;

	public Transform sightStart;
	public Transform sightEnd;

	public LayerMask detectWhat;

	public Transform weakness;

	public bool colliding;

	Animator anim;

	// Use this for initialization
	void Start () {

		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		m_Rigidbody2D.velocity = new Vector2 (velocity, m_Rigidbody2D.velocity.y);

		colliding = Physics2D.Linecast (sightStart.position, sightEnd.position, detectWhat);

		if (colliding) {
			transform.localScale=new Vector2 (transform.localScale.x * -1, transform.localScale.y);
			velocity*=-1;

		}

		if(GetComponent<EnemyDestructableHealth>().health <= 0)
		{
			EnemyDies();
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.magenta;
		Gizmos.DrawLine (sightStart.position, sightEnd.position);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player") {

			float height = col.contacts[0].point.y - weakness.position.y;

			if(height>0)
			{
				EnemyDies();
				col.rigidbody.AddForce (new Vector2(0,200));


			}

		}


	}

	void EnemyDies()
	{
		anim.SetBool ("Stomped", true);
		Destroy (this.gameObject, 0.5f );
		gameObject.tag = "Neutralized";
		velocity = 0;

		
	}


}
