using UnityEngine;
using System.Collections;

public class blue_enemy_behavior : MonoBehaviour {

    Animator animator;
    Animation animation;

	// Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        animation = GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Blue enemy touched something!");
        if (col.gameObject.tag == "weapon")
        {
            this.GetComponent<Rigidbody2D>().position = new Vector3(this.GetComponent<Rigidbody2D>().position.x, 0, -9);
            StartCoroutine(teleport());
        }
    }

    IEnumerator teleport()
    {
        
        animator.SetBool("teleport", true);
        yield return new WaitForSeconds(0.5f);



        Destroy(this.gameObject);
    }

}
