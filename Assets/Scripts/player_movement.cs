using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class player_movement : MonoBehaviour {

    //variable declarations
    PlayerStats stats;
    KillObject kill;

	public string left = "a";			//player controls
	public string right = "d";
	public string attack = "Space";
	string face = "right";
    Vector2 move;
	public GameObject weapon;

	Text health_bar;

    bool isColliding;
	
	void Start () {
        stats = this.GetComponent<PlayerStats>();

		health_bar = GameObject.Find ("/Player/Canvas/health_bar").GetComponent<Text> ();

        kill = this.GetComponent<KillObject>();
	}

	void Update () {

        //if health runs out, kill the player
        if (stats.health <= 0)
        {
            kill.isDead = true;
        }

		health_bar.text = stats.health.ToString();

		if(Input.GetKey(left)) {
			move = new Vector2(-1,0);
			face = "left";
		}
		else if(Input.GetKey(right)) {
			move = new Vector2(1,0);
			face = "right";
		}
		else {
			move = new Vector2(0,0);
		}

		transform.rotation = Quaternion.identity;
		transform.position = new Vector3 (transform.position.x, 0, -8);
		transform.Translate(move * stats.agility * Time.deltaTime);


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

        //if the player hits an enemy, detract from health
		if (thing.gameObject.tag == "Enemy") 
        {
			Debug.Log ("Enemy hit!");
			stats.health -= thing.gameObject.GetComponent<EnemyStats>().strength;
		}
            //if the player hits a health, add to health
		else if (thing.gameObject.tag == "health") {
			Debug.Log ("5 health added");
			stats.health += 5;
			Destroy(thing.gameObject);
		}
	}
}
