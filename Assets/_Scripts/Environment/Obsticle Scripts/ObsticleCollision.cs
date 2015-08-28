using UnityEngine;
using System.Collections;

public class ObsticleCollision : MonoBehaviour
{

    // Call relivant methods in here should player collide with an obsticle
    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.tag == "Player")
        {
            Debug.Log("Hit player");
            Debug.Log("Call death method");
        }
    }
}
