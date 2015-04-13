using UnityEngine;
using System.Collections;

public class KillObject : MonoBehaviour {

    public bool isDead = false;

    public GameObject particle;

    public Color particle_color;

    //kill the game object and create explosion
    void Update()
    {
        if (isDead == true)
        {
            Kill();
        }
    }

    void Kill()
    {
        Destroy(this.gameObject);

        for (int i = 0; i < 10; i++)
        {
            //instantiate particle and give it a velocity
            GameObject particleClone = Instantiate(particle, new Vector3(this.GetComponent<Rigidbody2D>().position.x, this.GetComponent<Rigidbody2D>().position.y, -6), Quaternion.identity) as GameObject;
            particleClone.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));

            //correct color of pixel
            float correction = Random.Range(-0.3f, 0.3f);
            particle_color += new Color(correction, correction, correction);

            //set texture color
            Texture2D particle_texture = new Texture2D(1, 1);
            particle_texture.SetPixel(1, 0, particle_color);
            particle_texture.Apply();
            particleClone.GetComponent<Renderer>().material.mainTexture = particle_texture;
        }
    }
}
