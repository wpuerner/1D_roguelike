using UnityEngine;
using System.Collections;

public class sword_behavior : MonoBehaviour {

	string attack;

	// Use this for initialization
	void Start () {
		attack = this.transform.parent.gameObject.GetComponent<player_movement> ().attack;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (attack)) {
			Destroy (this.gameObject);
		}
	
	}
}
