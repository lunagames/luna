using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
		public GameObject Player;
		//added eventhappened code to stop this happening twice due 2 player having 2 box colliders
		bool eventhappned = false;

		void Awake()
		{
			Player = GameObject.FindGameObjectWithTag ("Player");
		}

        private void OnTriggerEnter2D(Collider2D other)
        {
			if (other.tag == "Player" && eventhappned == false) {
				Player pstats = Player.GetComponent<Player> ();
				pstats.DeathIdentifier ();
				Debug.Log ("Player Death - Collision Detected");
				eventhappned = true;
			} else {
				eventhappned=false;
			}



        }
    }
}
