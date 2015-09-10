using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.gameObject.tag == "Fireball")
		{
			GameObject.Destroy(col.gameObject);
		}

	}
}
