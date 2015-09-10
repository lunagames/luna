using UnityEngine;
using System.Collections;

public class ChargePoint : MonoBehaviour {

    // Use this for initialization
    AudioSource efx;
    void Start () {
        efx = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            //Time.timeScale =0;
            UIManager.Instance.ShowPicker();
            efx.Play();
        }
    }


    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            UIManager.Instance.apBarDraining=true;
        }
    }
}
