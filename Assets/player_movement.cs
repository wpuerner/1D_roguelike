using UnityEngine;
using System.Collections;

public class player_movement : MonoBehaviour {

	public int player_speed = 10;
	public string left = "a";
	public string right = "d";

	Vector3 move;
	
	void Update () {
		if(Input.GetKey(left)) {
			move = new Vector3(-1,0,0);
		}
		else if(Input.GetKey(right)) {
			move = new Vector3(1,0,0);
		}
		else {
			move = new Vector3(0,0,0);
		}

		transform.Translate(move * player_speed * Time.deltaTime);

	}
}
