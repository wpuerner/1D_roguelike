using UnityEngine;
using System.Collections;

public class blue_enemy_behavior : MonoBehaviour {

    Animator animator;
    Rigidbody2D rb;

    SpriteRenderer rend;
    BoxCollider2D col;

    GameObject player;
    Rigidbody2D player_rb;

    EnemyStats stats;

    public int rush_speed = 2;

    KillObject kill;

	// Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();

        rend = this.GetComponent<SpriteRenderer>();
        col = this.GetComponent<BoxCollider2D>();

        stats = this.GetComponent<EnemyStats>();

        player = GameObject.FindWithTag("Player");
        player_rb = player.GetComponent<Rigidbody2D>();

        kill = this.GetComponent<KillObject>();
    }
	
	void Update () {

        rb.position = new Vector2(rb.position.x, 0);

        if (stats.health <= 0)
        {
            kill.isDead = true;
        }
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "weapon" && this.GetComponent<Rigidbody2D>().velocity == new Vector2(0,0))
        {
            StartCoroutine(teleport());
        }
        else if (col.gameObject.tag == "weapon" && this.GetComponent<Rigidbody2D>().velocity != new Vector2(0,0))
        {
            stats.health -= col.gameObject.GetComponent<WeaponStats>().strength;
        }
    }

    IEnumerator teleport()
    {

        
        animator.SetBool("teleport", true);
        animator.SetBool("idle", false);
        yield return new WaitForSeconds(0.4f);

        rend.enabled = false;
        col.enabled = false;

        yield return new WaitForSeconds(Random.Range(0, 3));

        rush();
        
    }

    void rush()
    {
        float teleport_range = Random.Range(20.0f, 21.0f);

        if (Random.Range(0.0f, 1.0f) < 0.5f)
        {
            teleport_range -= 2.0f * teleport_range;
        }

        Debug.Log(teleport_range.ToString());

        animator.SetBool("teleport", false);
        animator.SetBool("idle", true);

        rend.enabled = true;
        col.enabled = true;

        rb.position.x = player_rb.position.x + teleport_range;
        rb.velocity = new Vector2((player_rb.position.x - rb.position.x) * rush_speed, 0);

    }

}
