using UnityEngine;
using System.Collections;

public class LevelDoor : MonoBehaviour {
	public static int collectedCount;
	public bool isOpen = false;

	private int totalCollectableCount;
	Animator animator;

	void Awake(){
		animator = GetComponent<Animator>();
	}
	// Use this for initialization
	void Start () {
		totalCollectableCount = collectedCount;
		collectedCount = 0;
		Debug.Log (totalCollectableCount + " : " + collectedCount);
	}
	
	// Update is called once per frame
	void Update () {
		if(collectedCount == totalCollectableCount && !isOpen){
			isOpen = true;
			animator.SetBool("isOpen",true);
		}
	}
	void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			if(isOpen){
				LoadNextLevel();
			}
		}
	}
	void LoadNextLevel(){

	}
}
