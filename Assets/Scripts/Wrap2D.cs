using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap2D : MonoBehaviour {

	// Update is called once per frame
	void FixedUpdate () {
        //If player's postion is below -3.65 then...
        if (transform.position.x <= -3.65f)
        {
            // Our new player position will = x (-3.65f, current y, current z);
            transform.position = new Vector3(3.65f, transform.position.y, transform.position.z);
        }
        //If player's postion is above 3.65 then...
        else if (transform.position.x >= 3.65f)
        {
            // Our new player position will = x (3.65f, current y, current z);
            transform.position = new Vector3(-3.65f, transform.position.y, transform.position.z);
        }
	}
}
