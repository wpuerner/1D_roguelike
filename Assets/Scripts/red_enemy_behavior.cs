using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class red_enemy_behavior : MonoBehaviour {

    //variable declarations
    EnemyStats stats;

	Text health_bar;

	int waitTime;
	int chargeSpeed;

	public int waitTimeLimit = 100;
	public int chargeSpeedLimit = 10;

	Rigidbody2D rb;

    KillObject kill;

	void Start () {

        stats = this.GetComponent<EnemyStats>();
        
		rb = this.GetComponent<Rigidbody2D> ();
		waitTime = (int)Mathf.Floor (Random.Range (0, waitTimeLimit));

        kill = this.GetComponent<KillObject>();

	}

	void Update () {
		//destroy if health runs out
		if (stats.health == 0) {
            kill.isDead = true;
		}

		//movement control
		transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
		transform.rotation = Quaternion.identity;

		waitTime--;

		if (waitTime == 0) {
			charge ();
			waitTime = (int)Mathf.Floor (Random.Range (0, waitTimeLimit));
		}

	}

    //if enemy gets hit
	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "weapon") {
				stats.health -= col.gameObject.GetComponent<WeaponStats>().strength;

            //show damage value

		}
	}

	void charge() {
		chargeSpeed = (int)Mathf.Floor (Random.Range (-chargeSpeedLimit, chargeSpeedLimit));
		rb.velocity = new Vector2 (chargeSpeed, 0);
	}

}
