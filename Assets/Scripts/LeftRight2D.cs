using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRight2D : MonoBehaviour {

    float platformSpeed = 2f;
    bool endPoint; //check

	
	// Update is called once per frame
	void Update () {
        platformSpeed = Random.Range(1f, 4f);

        if (endPoint)
        {
            transform.position += Vector3.right * platformSpeed * Time.deltaTime;
        }
        else
        {
            transform.position -= Vector3.right * platformSpeed * Time.deltaTime;
        }

        if(transform.position.x >= 3.65)
        {
            endPoint = false;
        }
        else if (transform.position.x <= -3.65){
            endPoint = true;
        }
	}
}
