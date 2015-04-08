using UnityEngine;
using System.Collections;

public class blue_enemy_behavior : MonoBehaviour {

    Animator animator;
    Rigidbody2D body;

    SpriteRenderer rend;
    BoxCollider2D collider;

	// Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
        body = this.GetComponent<Rigidbody2D>();

        rend = this.GetComponent<SpriteRenderer>();
        collider = this.GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Blue enemy touched something!");
        if (col.gameObject.tag == "weapon")
        {
            StartCoroutine(teleport());
        }
    }

    IEnumerator teleport()
    {
        
        animator.SetBool("teleport", true);
        animator.SetBool("idle", false);
        yield return new WaitForSeconds(0.4f);

        rend.enabled = false;
        collider.enabled = false;

        yield return new WaitForSeconds(Random.Range(0, 3));

        body.position = new Vector2(GameObject.Find("Player").GetComponent<Rigidbody2D>().position.x + Random.Range(-1, 1), 0);
        body.velocity = new Vector2(Random.Range(-2, 2), 0);

        animator.SetBool("teleport", false);
        animator.SetBool("idle", true);

        rend.enabled = true;
        collider.enabled = true;
    }

}
