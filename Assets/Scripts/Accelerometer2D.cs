using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer2D : MonoBehaviour {
    Animator animator;
    public float speed = 0.25f;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        float temp = Input.acceleration.x;
        transform.Translate(temp * speed, 0, 0);
	}

    void OnCollisionEnter2D(Collision2D Player)
    {
        if (Player.gameObject.CompareTag("groundd"))
        {
            animator.SetInteger("state", 1);
        }
    }
}
