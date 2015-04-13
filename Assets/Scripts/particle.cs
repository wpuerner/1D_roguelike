using UnityEngine;
using System.Collections;

public class particle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(death());
	}
	
    IEnumerator death()
    {
        yield return new WaitForSeconds(Random.Range(0.0f,1.0f));
        Destroy(this.gameObject);
    }
}
