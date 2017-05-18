using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlat2D : MonoBehaviour {
    Rigidbody2D rb;
    public AudioClip Boing; // get Sound effect

    public float jumpHeight = 1600f; //Players jump heigh when hitting trigger
    float VelY;                     // Variable that can be seen throughout the script and referenced to

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = Boing;
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //References our player's current velocity
        VelY = rb.velocity.y;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "JumpPlat" && VelY <= 0)
        {
            rb.velocity = new Vector2(0, 0); //null current velocity to 0
            rb.AddForce(new Vector2(0, jumpHeight)); //increase y force by jumpHeight

            GetComponent<AudioSource>().Play();

        }
    }
}
