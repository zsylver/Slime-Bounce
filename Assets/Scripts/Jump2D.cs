using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2D : MonoBehaviour {
    Animator animator;
    public AudioClip Squish; // get Sound effect
    public bool grounded;   //true or false whether grounded
    public float jumpHeight = 200f;    //Player jump height
    public Transform groundcheck; //object which will check if we are grounded

    Rigidbody2D rb;
    float groundRadius = .2f;   //radius around the groundcheck object that will detect if we are grounded or not
    public LayerMask ground;    //decide which layers count as grounded

    // Use this for initialization
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = Squish;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundRadius, ground);

        float VelY = rb.velocity.y;

        if(grounded && VelY <= 0) //check for ground collision only when falling downwards
        {
            // reset velocity so avoid to get a bigger impulse from times to time
            rb.velocity = new Vector2(0, 0); 

            rb.AddForce(new Vector2(0, jumpHeight));

            animator.SetInteger("state", 1);
            GetComponent<AudioSource>().Play();
        }
        else if (!grounded)
        {
            animator.SetInteger("state", 0);
        }
	}
}
