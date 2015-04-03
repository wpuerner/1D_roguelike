using UnityEngine;
using System.Collections;

public class generate_map : MonoBehaviour {

    public GameObject map;

	// Use this for initialization
	void Start () {

        Color[] colors = new Color[114];
        Texture2D texture = new Texture2D(114,1);

        map = GameObject.Find("Map");

        //sets an array of color in the green map
        for (int i = 0; i < 114; i++)
        {
            colors[i] = new Color((15.0f/255.0f), (40.0f/255.0f), 0.0f);
            float correction = Random.Range(-0.05f, 0.05f);
            colors[i] += new Color(correction, correction, correction);

        }

        //set pixels on map texture
        for (int i = 0; i < 114; i++)
        {
            texture.SetPixel(i - 114/2, 0, colors[i]);
        }
        texture.Apply();
        map.GetComponent<Renderer>().material.mainTexture = texture;

	}
	
}
