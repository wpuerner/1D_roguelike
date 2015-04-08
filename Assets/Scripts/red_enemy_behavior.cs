using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class red_enemy_behavior : MonoBehaviour {

	public int health = 10;

	Text health_bar;

	int waitTime;
	int chargeSpeed;

	public int waitTimeLimit = 100;
	public int chargeSpeedLimit = 10;

	Rigidbody2D rigidbody;

    Animator anim;

	void Start () {
		health_bar = GameObject.Find ("/red_enemy/Canvas/enemy_health_bar").GetComponent<Text>();
		rigidbody = this.GetComponent<Rigidbody2D> ();
		waitTime = (int)Mathf.Floor (Random.Range (0, waitTimeLimit));

        anim = this.GetComponent<Animator>();
	}

	void Update () {
		//display health
		health_bar.text = health.ToString ();

		//destroy if health runs out
		if (health == 0) {
			StartCoroutine(death());
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

	void OnCollisionEnter2D(Collision2D col) {
		if(col.gameObject.tag == "weapon") {
				health -= col.gameObject.GetComponent<sword_behavior>().attack_strength;
		}
	}

	void charge() {
		chargeSpeed = (int)Mathf.Floor (Random.Range (-chargeSpeedLimit, chargeSpeedLimit));
		rigidbody.velocity = new Vector2 (chargeSpeed, 0);
	}

    IEnumerator death() {
        GameObject.Find("/red_enemy/Canvas").SetActive(false);
        anim.SetBool("death", true);
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);
    }
}
