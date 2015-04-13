using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DamageValue : MonoBehaviour {

    public Color enemy_color;
    public Color player_color;

    public int speed = 10;
    public int rise_time = 30;

    public bool is_enemy = true;

    void Start()
    {
        if (is_enemy)
        {
            this.GetComponent<Text>().color = enemy_color;
        }
        else
        {
            this.GetComponent<Text>().color = player_color;
        }
    }

	// Update is called once per frame
	void Update () {
        for (int i = 0; i < rise_time; i++)
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
        Destroy(this.gameObject);
	}
}
