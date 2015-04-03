using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class player_movement : MonoBehaviour {

	public string left = "a";			//player controls
	public string right = "d";
	public string attack = "Space";
	Vector3 move;						//movement direction
	public int player_speed = 10;		//movement speed
	string face = "right";

	public int player_health = 20;		//maximum health
	public int current_health;			//current health

	public GameObject weapon;

	Text health_bar;

    bool isColliding;
	
	void Start () {
		current_health = player_health;

		health_bar = GameObject.Find ("/Player/Canvas/health_bar").GetComponent<Text> ();
	}

	void Update () {

        //this.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

		health_bar.text = current_health.ToString();

		if(Input.GetKey(left)) {
			move = new Vector3(-1,0,0);
			face = "left";
		}
		else if(Input.GetKey(right)) {
			move = new Vector3(1,0,0);
			face = "right";
		}
		else {
			move = new Vector3(0,0,0);
		}

		transform.rotation = Quaternion.identity;
		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		transform.Translate(move * player_speed * Time.deltaTime);


		if (Input.GetKeyDown (attack)) {
			if(face == "right") {
				GameObject childWeapon = Instantiate(weapon, new Vector3(transform.position.x + 1,0,-8), Quaternion.identity) as GameObject;
				childWeapon.transform.parent = this.transform;
			}
			else if(face == "left") {
				GameObject childWeapon = Instantiate(weapon, new Vector3(transform.position.x - 1,0,-8), Quaternion.identity) as GameObject;
				childWeapon.transform.parent = this.transform;
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D thing) {
		if (thing.gameObject.tag == "red_enemy") {
			Debug.Log ("Red enemy hit!");
			current_health -= 1;
		} 
		else if (thing.gameObject.tag == "health") {
			Debug.Log ("5 health added");
			current_health += 5;
			Destroy(thing.gameObject);
		}
	}
}
